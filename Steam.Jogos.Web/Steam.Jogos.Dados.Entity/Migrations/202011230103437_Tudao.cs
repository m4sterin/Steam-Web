namespace Steam.Jogos.Dados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tudao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dlc",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        NomeDlc = c.String(nullable: false, maxLength: 100),
                        Descricao = c.String(maxLength: 1000),
                        Preco = c.Int(nullable: false),
                        IdJogo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jogo", t => t.IdJogo, cascadeDelete: true)
                .Index(t => t.IdJogo);
            
            AddColumn("dbo.Jogo", "EmailDev", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dlc", "IdJogo", "dbo.Jogo");
            DropIndex("dbo.Dlc", new[] { "IdJogo" });
            DropColumn("dbo.Jogo", "EmailDev");
            DropTable("dbo.Dlc");
        }
    }
}
