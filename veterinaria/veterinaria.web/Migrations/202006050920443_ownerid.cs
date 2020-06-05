namespace veterinaria.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ownerid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Owners", name: "ApplicationUser_Id", newName: "OwnerId");
            RenameIndex(table: "dbo.Owners", name: "IX_ApplicationUser_Id", newName: "IX_OwnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Owners", name: "IX_OwnerId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Owners", name: "OwnerId", newName: "ApplicationUser_Id");
        }
    }
}
