namespace AngularJSEFWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedDataForEmployees : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Employees (FirstName, LastName, Description, DateofBirth, Country, State, Salary, IsActive) VALUES ('Sean', 'Kotner', 'this is guy, really awesome', '03/02/1998', 'USA', 'CA', '90000', 1)");
            Sql("INSERT INTO Employees (FirstName, LastName, Description, DateofBirth, Country, State, Salary, IsActive) VALUES ('Kim', 'Walker', 'this is girl, really beautiful', '07/22/1978', 'USA', 'CA', '90000', 0 )");
        }
        
        public override void Down()
        {
        }
    }
}
