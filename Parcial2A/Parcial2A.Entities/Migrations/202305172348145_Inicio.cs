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
                        CantidadAdministrada = c.String(),
                        Personas_PersonaId = c.Int(),
                    })
                .PrimaryKey(t => t.DosisId)
                .ForeignKey("dbo.Personas", t => t.Personas_PersonaId)
                .Index(t => t.Personas_PersonaId);
            
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
                .PrimaryKey(t => t.PersonaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dosis", "Personas_PersonaId", "dbo.Personas");
            DropIndex("dbo.Dosis", new[] { "Personas_PersonaId" });
            DropTable("dbo.Personas");
            DropTable("dbo.Dosis");
        }
    }
}
