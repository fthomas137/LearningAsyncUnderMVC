namespace LearningAsyncUnderMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDepartmentValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Location", c => c.String());
            AlterColumn("dbo.Departments", "Name", c => c.String());
        }
    }
}
