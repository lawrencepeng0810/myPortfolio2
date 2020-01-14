using MvcHtmlHelpers.Models;

namespace MvcHtmlHelpers.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcHtmlHelpers.Models.CmsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcHtmlHelpers.Models.CmsContext context)
        {

            context.EmployeesNews.AddOrUpdate (
                x => x.Id,
                new EmployeesNew { Id = 1, Name = "David", Mobile = "0935-155222", Email = "david@gmai.com", Department = "總經理室", Title = "CEO" },
                new EmployeesNew { Id = 2, Name = "Mary", Mobile = "0938-123556", Email = "mary@gmai.com", Department = "人事部", Title = "管理師" },
                new EmployeesNew { Id = 3, Name = "Joe", Mobile = "0925-331225", Email = "joe@gmai.com", Department = "財務部", Title = "經理" }, 
                new EmployeesNew { Id = 4, Name = "Mark", Mobile = "0935-863991", Email = "mark@gmai.com", Department = "業務部", Title = "業務員" },
                new EmployeesNew { Id = 5, Name = "Rose", Mobile = "0987-335668", Email = "rose@gmai.com", Department = "資訊部", Title = "工程師" }
            );

            context.Registers.AddOrUpdate (
                x => x.Id,
                new Register {
                    Id = 1, Name = "奚江華", Nickname = "聖殿祭司", Password = "MyPassword*", Email = "david@gmai.com", City = 4,
                    Gender = 1, Commutermode = "1", Comment = "Nothing", Terms = true
                }
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
