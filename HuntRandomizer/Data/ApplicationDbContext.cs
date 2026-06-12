using HuntRandomizer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace HuntRandomizer.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<RegisteredUser>(options)
    {
        public DbSet<Tool> Tools { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        public DbSet<Consumable> Consumables { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemBase>().UseTpcMappingStrategy();

            modelBuilder.Entity<ItemBase>().OwnsOne(i => i.StaminaCost, stamina =>
            {
                stamina.Property(s => s.StaminaCostLight).HasColumnName("StaminaCostLight");
                stamina.Property(s => s.StaminaCostHeavy).HasColumnName("StaminaCostHeavy");
            });

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            this.ApplyAuditData();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.ApplyAuditData();

            return await base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditData()
        {
            var now = DateTime.UtcNow;

            foreach(var entry in ChangeTracker.Entries<ItemBase>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = now;
                        entry.Entity.ChangedAt = null;
                        entry.Entity.Restore();
                        break;

                    case EntityState.Modified:
                        entry.Entity.ChangedAt = now;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Delete();
                        break;
                }
            }
        }
    }
}
