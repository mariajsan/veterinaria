namespace veterinaria.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StructDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsultDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 50),
                        ConsultType = c.String(nullable: false, maxLength: 20),
                        Pet_Id = c.Int(),
                        Veterinary_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pets", t => t.Pet_Id)
                .ForeignKey("dbo.Veterinaries", t => t.Veterinary_Id)
                .Index(t => t.Pet_Id)
                .Index(t => t.Veterinary_Id);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        PetType = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 20),
                        Race = c.String(maxLength: 20),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owners", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Veterinaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 100),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Consult_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Consults", t => t.Consult_Id)
                .Index(t => t.Consult_Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "ImgUrl", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Managers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Histories", "Consult_Id", "dbo.Consults");
            DropForeignKey("dbo.Consults", "Veterinary_Id", "dbo.Veterinaries");
            DropForeignKey("dbo.Veterinaries", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners");
            DropForeignKey("dbo.Owners", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Consults", "Pet_Id", "dbo.Pets");
            DropIndex("dbo.Managers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Histories", new[] { "Consult_Id" });
            DropIndex("dbo.Veterinaries", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Owners", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pets", new[] { "Owner_Id" });
            DropIndex("dbo.Consults", new[] { "Veterinary_Id" });
            DropIndex("dbo.Consults", new[] { "Pet_Id" });
            DropColumn("dbo.AspNetUsers", "ImgUrl");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Managers");
            DropTable("dbo.Histories");
            DropTable("dbo.Veterinaries");
            DropTable("dbo.Owners");
            DropTable("dbo.Pets");
            DropTable("dbo.Consults");
        }
    }
}
