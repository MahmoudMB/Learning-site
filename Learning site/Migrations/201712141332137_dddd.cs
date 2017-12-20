namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddd : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.EnrolledCourses", new[] { "user_Id" });
            DropColumn("dbo.EnrolledCourses", "StudentId");
            RenameColumn(table: "dbo.EnrolledCourses", name: "user_Id", newName: "StudentId");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.EnrolledCourses", "StudentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.EnrolledCourses", new[] { "StudentId" });
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String());
            RenameColumn(table: "dbo.EnrolledCourses", name: "StudentId", newName: "user_Id");
            AddColumn("dbo.EnrolledCourses", "StudentId", c => c.String());
            CreateIndex("dbo.EnrolledCourses", "user_Id");
        }
    }
}
