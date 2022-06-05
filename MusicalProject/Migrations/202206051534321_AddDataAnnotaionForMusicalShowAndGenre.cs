namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotaionForMusicalShowAndGenre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MusicalShows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.MusicalShows", new[] { "Band_Id" });
            DropIndex("dbo.MusicalShows", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MusicalShows", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.MusicalShows", "Band_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MusicalShows", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.MusicalShows", "Band_Id");
            CreateIndex("dbo.MusicalShows", "Genre_Id");
            AddForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MusicalShows", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MusicalShows", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "Genre_Id" });
            DropIndex("dbo.MusicalShows", new[] { "Band_Id" });
            AlterColumn("dbo.MusicalShows", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.MusicalShows", "Band_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.MusicalShows", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.MusicalShows", "Genre_Id");
            CreateIndex("dbo.MusicalShows", "Band_Id");
            AddForeignKey("dbo.MusicalShows", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
