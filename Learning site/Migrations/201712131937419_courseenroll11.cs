namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseenroll11 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.EnrolledCourses", "StudentId");
            DropColumn("dbo.EnrolledCourses", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnrolledCourses", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String());
            AddPrimaryKey("dbo.EnrolledCourses", "Id");
        }
    }
}
