namespace veterinaria.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consults", "Pet_Id", "dbo.Pets");
            DropForeignKey("dbo.Consults", "Veterinary_Id", "dbo.Veterinaries");
            DropForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners");
            DropForeignKey("dbo.Histories", "Consult_Id", "dbo.Consults");
            DropIndex("dbo.Consults", new[] { "Pet_Id" });
            DropIndex("dbo.Consults", new[] { "Veterinary_Id" });
            DropIndex("dbo.Pets", new[] { "Owner_Id" });
            DropIndex("dbo.Histories", new[] { "Consult_Id" });
            RenameColumn(table: "dbo.Consults", name: "Pet_Id", newName: "PetId");
            RenameColumn(table: "dbo.Consults", name: "Veterinary_Id", newName: "VetId");
            RenameColumn(table: "dbo.Pets", name: "Owner_Id", newName: "OwnerId");
            RenameColumn(table: "dbo.Histories", name: "Consult_Id", newName: "ConsultId");
            AlterColumn("dbo.Consults", "PetId", c => c.Int(nullable: false));
            AlterColumn("dbo.Consults", "VetId", c => c.Int(nullable: false));
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Histories", "ConsultId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consults", "VetId");
            CreateIndex("dbo.Consults", "PetId");
            CreateIndex("dbo.Pets", "OwnerId");
            CreateIndex("dbo.Histories", "ConsultId");
            AddForeignKey("dbo.Consults", "PetId", "dbo.Pets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Consults", "VetId", "dbo.Veterinaries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Pets", "OwnerId", "dbo.Owners", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Histories", "ConsultId", "dbo.Consults", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Histories", "ConsultId", "dbo.Consults");
            DropForeignKey("dbo.Pets", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.Consults", "VetId", "dbo.Veterinaries");
            DropForeignKey("dbo.Consults", "PetId", "dbo.Pets");
            DropIndex("dbo.Histories", new[] { "ConsultId" });
            DropIndex("dbo.Pets", new[] { "OwnerId" });
            DropIndex("dbo.Consults", new[] { "PetId" });
            DropIndex("dbo.Consults", new[] { "VetId" });
            AlterColumn("dbo.Histories", "ConsultId", c => c.Int());
            AlterColumn("dbo.Pets", "OwnerId", c => c.Int());
            AlterColumn("dbo.Consults", "VetId", c => c.Int());
            AlterColumn("dbo.Consults", "PetId", c => c.Int());
            RenameColumn(table: "dbo.Histories", name: "ConsultId", newName: "Consult_Id");
            RenameColumn(table: "dbo.Pets", name: "OwnerId", newName: "Owner_Id");
            RenameColumn(table: "dbo.Consults", name: "VetId", newName: "Veterinary_Id");
            RenameColumn(table: "dbo.Consults", name: "PetId", newName: "Pet_Id");
            CreateIndex("dbo.Histories", "Consult_Id");
            CreateIndex("dbo.Pets", "Owner_Id");
            CreateIndex("dbo.Consults", "Veterinary_Id");
            CreateIndex("dbo.Consults", "Pet_Id");
            AddForeignKey("dbo.Histories", "Consult_Id", "dbo.Consults", "Id");
            AddForeignKey("dbo.Pets", "Owner_Id", "dbo.Owners", "Id");
            AddForeignKey("dbo.Consults", "Veterinary_Id", "dbo.Veterinaries", "Id");
            AddForeignKey("dbo.Consults", "Pet_Id", "dbo.Pets", "Id");
        }
    }
}
