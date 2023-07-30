namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.TblStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 200),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.TblCourses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TblStudents", "CourseId", "dbo.TblCourses");
            DropIndex("dbo.TblStudents", new[] { "CourseId" });
            DropTable("dbo.TblStudents");
            DropTable("dbo.TblCourses");
        }
    }
}
