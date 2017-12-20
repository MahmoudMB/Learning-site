namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "subject");
        }
    }
}
