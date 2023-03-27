using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel.DataAnnotations;

namespace ContaCorrente.Models
{
    public class Extrato
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Cpf")]
        public string? Cpf { get; set; }

        [BsonElement("Valor")]
        public double Valor { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CriadoEm { get; set; }

        [BsonElement("Tipo")]
        public string? Tipo { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DeletadoEm { get; set; }

    }
}
