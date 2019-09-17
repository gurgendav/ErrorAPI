namespace ErrorAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProgramContactEmail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Errors", "Program_Id", "dbo.Programs");
            DropIndex("dbo.Errors", new[] { "Program_Id" });
            RenameColumn(table: "dbo.Errors", name: "Program_Id", newName: "Program_Name");
            DropPrimaryKey("dbo.Programs");
            AddColumn("dbo.Programs", "ContactEmail", c => c.String());
            AlterColumn("dbo.Errors", "Program_Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Programs", "Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Programs", "Name");
            CreateIndex("dbo.Errors", "Program_Name");
            AddForeignKey("dbo.Errors", "Program_Name", "dbo.Programs", "Name");
            DropColumn("dbo.Programs", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Programs", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Errors", "Program_Name", "dbo.Programs");
            DropIndex("dbo.Errors", new[] { "Program_Name" });
            DropPrimaryKey("dbo.Programs");
            AlterColumn("dbo.Programs", "Name", c => c.String());
            AlterColumn("dbo.Errors", "Program_Name", c => c.Int());
            DropColumn("dbo.Programs", "ContactEmail");
            AddPrimaryKey("dbo.Programs", "Id");
            RenameColumn(table: "dbo.Errors", name: "Program_Name", newName: "Program_Id");
            CreateIndex("dbo.Errors", "Program_Id");
            AddForeignKey("dbo.Errors", "Program_Id", "dbo.Programs", "Id");
        }
    }
}
