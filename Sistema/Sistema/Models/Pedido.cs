using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Pedido
    {
        [Key]
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public IList<PedidoItem> PedidoItems { get; set; }
    }
}