using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Telefone
    {
        public Telefone() {}

        public Telefone(int clienteId)
        {
            ClienteId = clienteId;
        }

        [Key]
        public int TelefoneId { get; set; }
        public int DDD { get; set; }
        public int TelefoneNumero { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}