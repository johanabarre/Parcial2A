namespace Parcial2A.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dosis",
                c => new
                    {
                        DosisId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Presentacion = c.String(nullable: false),
                        CantidadAdministrada = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DosisId);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        PersonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 30),
                        Edad = c.String(nullable: false),
                        Genero = c.String(nullable: false),
                        DosisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonaId)
                .ForeignKey("dbo.Dosis", t => t.DosisId, cascadeDelete: true)
                .Index(t => t.DosisId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personas", "DosisId", "dbo.Dosis");
            DropIndex("dbo.Personas", new[] { "DosisId" });
            DropTable("dbo.Personas");
            DropTable("dbo.Dosis");
        }
    }
}
