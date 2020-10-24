using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public long Cpf { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public IList<Telefone> Telefones { get; set; }
        public IList<Pedido> Pedidos { get; set; }
    }
}