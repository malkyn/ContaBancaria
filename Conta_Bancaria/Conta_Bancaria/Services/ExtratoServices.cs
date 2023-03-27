using AutoMapper;
using Conta_Bancaria.Data.DTO.UserDto;
using ContaCorrente.Data;
using ContaCorrente.Interfaces;
using ContaCorrente.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ContaCorrente.Services
{
    public class ExtratoServices : IExtratoInterface
    {
        private readonly IMongoCollection<Extrato> _operacaoCollection;

        public ExtratoServices(IOptions<DatabaseSettings> productServices, IMapper mapper)
        {
            var mongoClient = new MongoClient(productServices.Value.ConnectString);
            var mongoDatabase = mongoClient.GetDatabase(productServices.Value.DatabaseName);

            _operacaoCollection = mongoDatabase.GetCollection<Extrato>
                (productServices.Value.ExtratoCollection);
        }

        public Extrato Transacao(Extrato user)
        {
            user.CriadoEm = DateTime.Now.Date;
            _operacaoCollection.InsertOne(user);
            return user;
        }

        public Extrato Delete(string id)
        {
            var builder = Builders<Extrato>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(id));
            Extrato extrato = _operacaoCollection.Find(filter).FirstOrDefault();
            extrato.DeletadoEm = DateTime.Now;
            _operacaoCollection.ReplaceOne(x => x.Id == id, extrato);
            return extrato;
        }

        public ExtratoDto Extrato(string cpf, DateTime dateTime, DateTime finalDate)
        {
            ExtratoDto extratodto = new ExtratoDto();
            var builder = Builders<Extrato>.Filter;
            var filter = builder.StringIn(x => x.Cpf, cpf) & builder.Eq(x => x.DeletadoEm,null) & builder.Gte(x => x.CriadoEm, dateTime) & builder.Lt(x => x.CriadoEm, finalDate);
            List<Extrato> searchC = _operacaoCollection.Find(filter).ToList();
            var extrato = searchC.Select(x => new Transacao() { criadoEm = x.CriadoEm, Valor = x.Valor, Tipo = x.Tipo }).ToList();
            extratodto.Transacoes = extrato;
            extratodto.Balanceamento();

            return extratodto;
        }
    }
}