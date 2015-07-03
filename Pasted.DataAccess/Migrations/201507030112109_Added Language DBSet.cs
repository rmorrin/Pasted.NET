namespace Pasted.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLanguageDBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PrismName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pastes", "Title", c => c.String());
            AddColumn("dbo.Pastes", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pastes", "ExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Pastes", "Private", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pastes", "Language_Id", c => c.Int());
            CreateIndex("dbo.Pastes", "Language_Id");
            AddForeignKey("dbo.Pastes", "Language_Id", "dbo.Languages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pastes", "Language_Id", "dbo.Languages");
            DropIndex("dbo.Pastes", new[] { "Language_Id" });
            DropColumn("dbo.Pastes", "Language_Id");
            DropColumn("dbo.Pastes", "Private");
            DropColumn("dbo.Pastes", "ExpiryDate");
            DropColumn("dbo.Pastes", "CreatedDate");
            DropColumn("dbo.Pastes", "Title");
            DropTable("dbo.Languages");
        }
    }
}
