using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using MasterOfFraudSecurity.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MasterOfFraudSecurity.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MasterOfFraudSecurity", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new DbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Questionary> Questionaries { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        //protected override void Seed(ApplicationDbContext context)
        //{
        //    context.Questionaries.AddOrUpdate(q => q.IINPhysic, new Questionary[]
        //    {
        //        new Questionary
        //        {
        //            FirstName = "z",
        //            LastName = "x",
        //            Patronymic = "c",
        //            BirthDate = DateTime.Now.AddYears(-25)
        //        }
        //    });
        //}
    }
}