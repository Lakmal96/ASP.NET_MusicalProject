namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMusicalShowTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MusicalShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Venue = c.String(),
                        Band_Id = c.String(maxLength: 128),
                        Genre_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Band_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .Index(t => t.Band_Id)
                .Index(t => t.Genre_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MusicalShows", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "Genre_Id" });
            DropIndex("dbo.MusicalShows", new[] { "Band_Id" });
            DropTable("dbo.MusicalShows");
            DropTable("dbo.Genres");
        }
    }
}
