namespace Sistema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration_001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Cpf = c.Long(nullable: false),
                        CategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId, cascadeDelete: true)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Rua = c.String(),
                        Numero = c.Int(nullable: false),
                        Bairro = c.String(),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnderecoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.PedidoItems",
                c => new
                    {
                        PedidoItemId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoItemId)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.PedidoId);
            
            CreateTable(
                "dbo.Telefones",
                c => new
                    {
                        TelefoneId = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        TelefoneNumero = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TelefoneId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telefones", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.PedidoItems", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Enderecoes", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Telefones", new[] { "ClienteId" });
            DropIndex("dbo.PedidoItems", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.Enderecoes", new[] { "ClienteId" });
            DropIndex("dbo.Clientes", new[] { "CategoriaId" });
            DropTable("dbo.Telefones");
            DropTable("dbo.PedidoItems");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Categorias");
        }
    }
}
