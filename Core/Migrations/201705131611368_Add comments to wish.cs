namespace Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addcommentstowish : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Creator = c.String(),
                        Created = c.DateTime(nullable: false),
                        Wish_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Wish", t => t.Wish_Id, cascadeDelete: true)
                .Index(t => t.Wish_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "Wish_Id", "dbo.Wish");
            DropIndex("dbo.Comment", new[] { "Wish_Id" });
            DropTable("dbo.Comment");
        }
    }
}
