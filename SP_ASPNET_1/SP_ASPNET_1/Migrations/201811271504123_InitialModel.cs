namespace SP_ASPNET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.AuthorID);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Content = c.String(),
                        ImageUrl = c.String(),
                        Author_AuthorID = c.Int(),
                    })
                .PrimaryKey(t => t.BlogPostID)
                .ForeignKey("dbo.Authors", t => t.Author_AuthorID)
                .Index(t => t.Author_AuthorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "Author_AuthorID", "dbo.Authors");
            DropIndex("dbo.BlogPosts", new[] { "Author_AuthorID" });
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Authors");
        }
    }
}
