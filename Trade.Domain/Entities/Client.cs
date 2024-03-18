using MongoDB.Bson.Serialization.Attributes;
using Trade.Domain.Entities.Documents;
using Trade.Domain.Helpers;

namespace Trade.Domain.Entities
{
    [BsonCollection("clients")]
    public class Client : Document
    {
        [BsonElement("nome")]
        public string Nome { get; set; }
       
        [BsonElement("cpf")]
        public string CPF { get; set; }
        
        [BsonElement("endereco")]
        public string Endereco { get; set; }
       
        [BsonElement("cidade")]
        public string Cidade { get; set; }
       
        [BsonElement("estado")]
        public string Estado { get; set; }
        
        [BsonElement("ddd")]
        public string DDD { get; set; }
        
        [BsonElement("telefone")]
        public string Telefone { get; set; }

        public Client(string nome, string cpf, string endereco, string cidade, string estado, string ddd, string telefone)
        {
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            DDD = ddd;
            Telefone = telefone;
        }
    }
}
