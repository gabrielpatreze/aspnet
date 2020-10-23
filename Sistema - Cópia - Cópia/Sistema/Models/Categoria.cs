using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sistema.Models;

namespace Sistema.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
    }
}