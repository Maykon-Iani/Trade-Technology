namespace Trade.Domain.DTOs
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public int CPF { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int DDD { get; set; }
        public int Telefone { get; set; }
    }
}
