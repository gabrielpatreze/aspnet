using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Sistema.Models;

namespace Sistema.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("SistemaConnection1")
        {
        }

        public System.Data.Entity.DbSet<Sistema.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<Sistema.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<Sistema.Models.Endereco> Enderecoes { get; set; }

        public System.Data.Entity.DbSet<Sistema.Models.Pedido> Pedidoes { get; set; }
    }
}