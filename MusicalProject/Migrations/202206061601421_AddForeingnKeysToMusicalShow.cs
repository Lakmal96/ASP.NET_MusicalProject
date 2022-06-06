namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeingnKeysToMusicalShow : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "Band_Id" });
            RenameColumn(table: "dbo.MusicalShows", name: "Band_Id", newName: "BandId");
            RenameColumn(table: "dbo.MusicalShows", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.MusicalShows", name: "IX_Genre_Id", newName: "IX_GenreId");
            AlterColumn("dbo.MusicalShows", "BandId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MusicalShows", "BandId");
            AddForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "BandId" });
            AlterColumn("dbo.MusicalShows", "BandId", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.MusicalShows", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.MusicalShows", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.MusicalShows", name: "BandId", newName: "Band_Id");
            CreateIndex("dbo.MusicalShows", "Band_Id");
            AddForeignKey("dbo.MusicalShows", "Band_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
