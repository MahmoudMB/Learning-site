namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubject1111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assignments", "courseId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Assignments", "courseId", c => c.String());
        }
    }
}
