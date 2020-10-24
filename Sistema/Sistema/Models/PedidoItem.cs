using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class PedidoItem
    {
        public PedidoItem() {}

        public PedidoItem(int pedidoId)
        {
            PedidoId = pedidoId;
        }

        [Key]
        public int PedidoItemId { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public Pedido Pedido { get; set; }
        public int PedidoId { get; set; }
    }
}