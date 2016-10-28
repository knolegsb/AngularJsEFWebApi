namespace AngularJSEFWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactDataSeed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Contacts (Name, Address, Phone) VALUES ('Sean', '2132 Gilbert Ave. Anaheim CA 92910', '324-342-3424')");
        }
        
        public override void Down()
        {
        }
    }
}
