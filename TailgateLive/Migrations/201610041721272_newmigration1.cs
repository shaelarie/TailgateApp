namespace TailgateLive.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamUsers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.User_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Events", "User_Id", c => c.Int());
            AddColumn("dbo.Users", "EmailId", c => c.String(maxLength: 128));
            AddColumn("dbo.Users", "Event_Id", c => c.Int());
            CreateIndex("dbo.Events", "User_Id");
            CreateIndex("dbo.Users", "EmailId");
            CreateIndex("dbo.Users", "Event_Id");
            AddForeignKey("dbo.Users", "EmailId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Events", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Users", "Event_Id", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.TeamUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.TeamUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Events", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "EmailId", "dbo.AspNetUsers");
            DropIndex("dbo.TeamUsers", new[] { "User_Id" });
            DropIndex("dbo.TeamUsers", new[] { "Team_Id" });
            DropIndex("dbo.Users", new[] { "Event_Id" });
            DropIndex("dbo.Users", new[] { "EmailId" });
            DropIndex("dbo.Events", new[] { "User_Id" });
            DropColumn("dbo.Users", "Event_Id");
            DropColumn("dbo.Users", "EmailId");
            DropColumn("dbo.Events", "User_Id");
            DropTable("dbo.TeamUsers");
        }
    }
}
