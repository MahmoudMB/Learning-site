namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubject111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignments", "course_Id", "dbo.Courses");
            DropIndex("dbo.Assignments", new[] { "course_Id" });
            DropColumn("dbo.Assignments", "course_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assignments", "course_Id", c => c.Int());
            CreateIndex("dbo.Assignments", "course_Id");
            AddForeignKey("dbo.Assignments", "course_Id", "dbo.Courses", "Id");
        }
    }
}
