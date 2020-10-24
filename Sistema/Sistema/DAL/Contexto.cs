using Sistema.Models;
using System.Data.Entity;

namespace Sistema.DAL
{
    public class Contexto : DbContext
    {
        public Contexto() : base("SistemaConnection1") {}

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Endereco> Enderecoes { get; set; }

        public DbSet<Pedido> Pedidoes { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Telefone> Telefones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }

    }
}