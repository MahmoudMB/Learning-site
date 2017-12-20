namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addasignmentmodel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EnrolledCourses");
            AddColumn("dbo.EnrolledCourses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String());
            AddPrimaryKey("dbo.EnrolledCourses", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.EnrolledCourses", "Id");
            AddPrimaryKey("dbo.EnrolledCourses", "StudentId");
        }
    }
}
