namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseenroll111 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.EnrolledCourses", "StudentId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EnrolledCourses");
            AlterColumn("dbo.EnrolledCourses", "StudentId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.EnrolledCourses", "StudentId");
        }
    }
}
