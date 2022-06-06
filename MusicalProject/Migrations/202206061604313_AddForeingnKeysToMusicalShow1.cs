namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeingnKeysToMusicalShow1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "BandId" });
            AlterColumn("dbo.MusicalShows", "BandId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.MusicalShows", "BandId");
            AddForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers");
            DropIndex("dbo.MusicalShows", new[] { "BandId" });
            AlterColumn("dbo.MusicalShows", "BandId", c => c.String(maxLength: 128));
            CreateIndex("dbo.MusicalShows", "BandId");
            AddForeignKey("dbo.MusicalShows", "BandId", "dbo.AspNetUsers", "Id");
        }
    }
}
