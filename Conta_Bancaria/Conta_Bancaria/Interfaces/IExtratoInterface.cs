using Conta_Bancaria.Data.DTO.UserDto;
using ContaCorrente.Models;
using MongoDB.Bson;

namespace ContaCorrente.Interfaces
{
    public interface IExtratoInterface
    {
        public Extrato Transacao(Extrato user);
        public Extrato Delete(string id);
        public ExtratoDto Extrato(string cpf, DateTime dateTime, DateTime finalDate);
    }
}