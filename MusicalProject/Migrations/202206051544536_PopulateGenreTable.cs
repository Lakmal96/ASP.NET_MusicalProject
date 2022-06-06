namespace MusicalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Heavy Metal')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Reggae')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4)");
        }
    }
}
