namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamePropertyToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
