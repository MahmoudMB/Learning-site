namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubject11 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Assignments", new[] { "StudentId" });
            CreateIndex("dbo.Assignments", "studentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Assignments", new[] { "studentId" });
            CreateIndex("dbo.Assignments", "StudentId");
        }
    }
}
