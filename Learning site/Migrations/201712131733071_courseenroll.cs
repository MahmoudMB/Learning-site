namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseenroll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrolledCourses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(),
                        CourseId = c.String(),
                        course_Id = c.Int(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.course_Id)
                .Index(t => t.user_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrolledCourses", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EnrolledCourses", "course_Id", "dbo.Courses");
            DropIndex("dbo.EnrolledCourses", new[] { "user_Id" });
            DropIndex("dbo.EnrolledCourses", new[] { "course_Id" });
            DropTable("dbo.EnrolledCourses");
        }
    }
}
