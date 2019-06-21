namespace directory_board_task_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(nullable: false, maxLength: 50),
                        Level = c.String(nullable: false, maxLength: 3),
                        Suite = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirectoryId = c.Int(),
                        Field = c.String(maxLength: 50),
                        From = c.String(maxLength: 50),
                        To = c.String(maxLength: 50),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logs");
            DropTable("dbo.Directories");
        }
    }
}
