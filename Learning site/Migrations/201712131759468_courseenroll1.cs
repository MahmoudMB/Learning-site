namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseenroll1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrolledCourses", "course_Id", "dbo.Courses");
            DropIndex("dbo.EnrolledCourses", new[] { "course_Id" });
            DropColumn("dbo.EnrolledCourses", "CourseId");
            RenameColumn(table: "dbo.EnrolledCourses", name: "course_Id", newName: "CourseId");
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EnrolledCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.EnrolledCourses", "CourseId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.EnrolledCourses", "Id");
            CreateIndex("dbo.EnrolledCourses", "CourseId");
            AddForeignKey("dbo.EnrolledCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrolledCourses", "CourseId", "dbo.Courses");
            DropIndex("dbo.EnrolledCourses", new[] { "CourseId" });
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "CourseId", c => c.Int());
            AlterColumn("dbo.EnrolledCourses", "CourseId", c => c.String());
            AlterColumn("dbo.EnrolledCourses", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.EnrolledCourses", "Id");
            RenameColumn(table: "dbo.EnrolledCourses", name: "CourseId", newName: "course_Id");
            AddColumn("dbo.EnrolledCourses", "CourseId", c => c.String());
            CreateIndex("dbo.EnrolledCourses", "course_Id");
            AddForeignKey("dbo.EnrolledCourses", "course_Id", "dbo.Courses", "Id");
        }
    }
}
