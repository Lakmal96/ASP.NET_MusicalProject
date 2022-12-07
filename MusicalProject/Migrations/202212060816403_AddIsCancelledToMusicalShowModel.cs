namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsCancelledToMusicalShowModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MusicalShows", "IsCancelled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MusicalShows", "IsCancelled");
        }
    }
}
