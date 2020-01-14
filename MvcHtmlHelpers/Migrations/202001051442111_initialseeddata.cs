namespace MvcHtmlHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialseeddata : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeesNews", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.EmployeesNews", "Mobile", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeesNews", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeesNews", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeesNews", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeesNews", "Title", c => c.String());
            AlterColumn("dbo.EmployeesNews", "Department", c => c.String());
            AlterColumn("dbo.EmployeesNews", "Email", c => c.String());
            AlterColumn("dbo.EmployeesNews", "Mobile", c => c.String());
            AlterColumn("dbo.EmployeesNews", "Name", c => c.String());
        }
    }
}
