using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using eGP.Abstration.Domain;
using eGP.Registration.Persistance.Configurations;
using eGP.Registration.Persistance.EntityModels;
using eGP.Registration.Persistance.Models;
using Microsoft.EntityFrameworkCore;

namespace eGP.Registration.Persistance.Contexts
{
    public class RegistrationDbContext : DbContext, IUnitOfWork
    {


        public RegistrationDbContext()
        {
         
        }
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> options) : base(options)
        {
           
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationStructure> OrganizationStructures { get; set; }

        public DbSet<Placement> Placements { get; set; }


        

        private void BeforeSaving(string userId)
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is EntityBaseGuid && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                var entity = ((EntityBaseGuid) entry.Entity);
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.DateCreated = DateTime.UtcNow;
                        entity.CreatedBy = Guid.Parse( userId);
                        break;
                    case EntityState.Modified:
                        entity.DateModified = DateTime.UtcNow;
                        entity.ModifiedBy = Guid.Parse(userId);
                        break;
                }
               
            }
        }

        public int SaveChanges(string userid)
        {
            BeforeSaving(userid);
            var id = base.SaveChanges();
            return id;
        }
        public Task<int> SaveChangesAsync(string userid, CancellationToken cancellationToken = default(CancellationToken))
        {
            BeforeSaving(userid);
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task<int> SaveEntitiesAsync(string userid, CancellationToken cancellationToken = default(CancellationToken))
        {
            BeforeSaving(userid);
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         modelBuilder.ApplyConfiguration(new OrganizationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
