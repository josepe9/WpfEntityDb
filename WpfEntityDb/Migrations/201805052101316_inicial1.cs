namespace WpfEntityDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Animals", newName: "Animal");
            RenameTable(name: "dbo.Razas", newName: "Raza");
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            AddColumn("dbo.Animal", "ColorID", c => c.Int(nullable: false));
            AlterColumn("dbo.Animal", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Animal", "ColorID");
            AddForeignKey("dbo.Animal", "ColorID", "dbo.Color", "ColorID", cascadeDelete: true);
            DropColumn("dbo.Animal", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animal", "Color", c => c.String());
            DropForeignKey("dbo.Animal", "ColorID", "dbo.Color");
            DropIndex("dbo.Animal", new[] { "ColorID" });
            AlterColumn("dbo.Animal", "Valor", c => c.Double(nullable: false));
            DropColumn("dbo.Animal", "ColorID");
            DropTable("dbo.Color");
            RenameTable(name: "dbo.Raza", newName: "Razas");
            RenameTable(name: "dbo.Animal", newName: "Animals");
        }
    }
}
