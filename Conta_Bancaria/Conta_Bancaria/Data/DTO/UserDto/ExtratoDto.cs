using MongoDB.Bson.Serialization.Attributes;

namespace Conta_Bancaria.Data.DTO.UserDto
{
    public class Transacao
    {
        [BsonElement("Tipo")]
        public string? Tipo { get; set; }

        [BsonElement("criadoEm")]
        public DateTime? criadoEm { get; set; }

        [BsonElement("Valor")]
        public double Valor { get; set; }
    }

    public class ExtratoDto
    {
        [BsonElement("Balanco")]
        public double Balanco { get; set; }

        public List<Transacao>? Transacoes { get; set; }
    }

    public static class ExtratoExtension
    {
        public static void Balanceamento(this ExtratoDto extrato)
        {
            if (extrato.Transacoes != null)
            {
                foreach (var item in extrato.Transacoes)
                {
                    if (item.Tipo == "Crédito")
                    {
                        extrato.Balanco -= item.Valor;
                    }
                    else if (item.Tipo == "Débito")
                    {
                        extrato.Balanco += item.Valor;
                    }
                }
            }
        }
    }
}