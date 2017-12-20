namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addasignmentmodel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Double(nullable: false),
                        StudentId = c.String(maxLength: 128),
                        CourseId = c.String(),
                        course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.course_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.course_Id);
            
            AddColumn("dbo.EnrolledCourses", "assignment_Id", c => c.Int());
            CreateIndex("dbo.EnrolledCourses", "assignment_Id");
            AddForeignKey("dbo.EnrolledCourses", "assignment_Id", "dbo.Assignments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrolledCourses", "assignment_Id", "dbo.Assignments");
            DropForeignKey("dbo.Assignments", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Assignments", "course_Id", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "course_Id" });
            DropIndex("dbo.Assignments", new[] { "StudentId" });
            DropIndex("dbo.EnrolledCourses", new[] { "assignment_Id" });
            DropColumn("dbo.EnrolledCourses", "assignment_Id");
            DropTable("dbo.Assignments");
        }
    }
}
