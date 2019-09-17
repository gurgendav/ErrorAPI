namespace ErrorAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateUtc = c.DateTime(nullable: false),
                        FaultingContextDetails = c.String(),
                        Version = c.String(),
                        MachineName = c.String(),
                        MachineOsVersion = c.String(),
                        UsedMemoryMb = c.Double(nullable: false),
                        UserName = c.String(),
                        CanUserContinue = c.Boolean(nullable: false),
                        DidUserContinue = c.Boolean(nullable: false),
                        Error_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Errors", t => t.Error_Id)
                .Index(t => t.Error_Id);
            
            CreateTable(
                "dbo.Errors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExceptionName = c.String(),
                        ExceptionType = c.String(),
                        ExceptionMessage = c.String(),
                        StackTrace = c.String(),
                        Program_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Programs", t => t.Program_Id)
                .Index(t => t.Program_Id);
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Errors", "Program_Id", "dbo.Programs");
            DropForeignKey("dbo.ErrorDetails", "Error_Id", "dbo.Errors");
            DropIndex("dbo.Errors", new[] { "Program_Id" });
            DropIndex("dbo.ErrorDetails", new[] { "Error_Id" });
            DropTable("dbo.Programs");
            DropTable("dbo.Errors");
            DropTable("dbo.ErrorDetails");
        }
    }
}
