using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sistema.Models;

namespace Sistema.Models
{
    public class Pedido
    {
        [Key]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public string Data { get; set; }

        // add +   aqui lista de pedidos 



    }
}