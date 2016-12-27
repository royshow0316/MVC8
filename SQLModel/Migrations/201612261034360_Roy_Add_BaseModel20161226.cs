namespace SQLModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Roy_Add_BaseModel20161226 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Projects", "CreatorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Projects", "ModifyId", c => c.String(maxLength: 128));
            AddColumn("dbo.Structures", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Structures", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Structures", "CreatorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Structures", "ModifyId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "CreatorId");
            CreateIndex("dbo.Projects", "ModifyId");
            CreateIndex("dbo.Structures", "CreatorId");
            CreateIndex("dbo.Structures", "ModifyId");
            AddForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Projects", "ModifyId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Structures", "CreatorId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Structures", "ModifyId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Structures", "ModifyId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Structures", "CreatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "ModifyId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Projects", "CreatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Structures", new[] { "ModifyId" });
            DropIndex("dbo.Structures", new[] { "CreatorId" });
            DropIndex("dbo.Projects", new[] { "ModifyId" });
            DropIndex("dbo.Projects", new[] { "CreatorId" });
            DropColumn("dbo.Structures", "ModifyId");
            DropColumn("dbo.Structures", "CreatorId");
            DropColumn("dbo.Structures", "ModifyDate");
            DropColumn("dbo.Structures", "CreateDate");
            DropColumn("dbo.Projects", "ModifyId");
            DropColumn("dbo.Projects", "CreatorId");
            DropColumn("dbo.Projects", "ModifyDate");
            DropColumn("dbo.Projects", "CreateDate");
        }
    }
}
