namespace WpfEntityDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primera : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animal",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RazaID = c.Int(nullable: false),
                        FechaNac = c.DateTime(nullable: false),
                        ColorID = c.Int(nullable: false),
                        Peso = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AnimalID)
                .ForeignKey("dbo.Color", t => t.ColorID, cascadeDelete: true)
                .ForeignKey("dbo.Raza", t => t.RazaID, cascadeDelete: true)
                .Index(t => t.RazaID)
                .Index(t => t.ColorID);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Raza",
                c => new
                    {
                        RazaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Detalle = c.String(),
                    })
                .PrimaryKey(t => t.RazaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animal", "RazaID", "dbo.Raza");
            DropForeignKey("dbo.Animal", "ColorID", "dbo.Color");
            DropIndex("dbo.Animal", new[] { "ColorID" });
            DropIndex("dbo.Animal", new[] { "RazaID" });
            DropTable("dbo.Raza");
            DropTable("dbo.Color");
            DropTable("dbo.Animal");
        }
    }
}
