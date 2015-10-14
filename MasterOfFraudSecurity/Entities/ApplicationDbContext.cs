using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Questionary> Questionaries { get; set; }
    }
}