using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sistema.Models;

namespace Sistema.Models
{
    public class Telefone
    {
        [Key]
        public int TelefoneId { get; set; }
        public int DDD { get; set; }
        public int TelefoneNumero { get; set; }

        //tipo de telefone
        //public TipoTelefone Tipo { get; set; }

    }
}