using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Endereco
    {
        public Endereco() {}

        public Endereco(int clienteId)
        {
            ClienteId = clienteId;
        }

        [Key]
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}