namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TblStudents", "city", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TblStudents", "city");
        }
    }
}
