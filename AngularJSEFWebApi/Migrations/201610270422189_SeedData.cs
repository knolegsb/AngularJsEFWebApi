namespace AngularJSEFWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedData : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Products ADD Description text");
        }

        public override void Down()
        {
        }
    }
}
