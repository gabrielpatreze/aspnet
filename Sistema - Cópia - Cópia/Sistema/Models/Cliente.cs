using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Sistema.Models;

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

        public string Endereco1 { get; set; }


        // add +   aqui lista de endereco baseada na classe Endereço
        //public Endereco Endereco { get; set; }

        // add +   aqui lista de telefones baseada na classe Telefone
        //public Telefone Telefone { get; set; }
    }
}