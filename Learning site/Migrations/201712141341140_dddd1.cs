namespace Learning_site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "File");
        }
    }
}
