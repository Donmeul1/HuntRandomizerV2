using HuntRandomizer.Models;
using HuntRandomizer.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HuntRandomizer.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<RegisteredUser>(options)
    {
        //public DbSet<Tool> Tools { get; set; }

        public DbSet<Weapon> Weapons { get; set; }

        //public DbSet<Consumable> Consumables { get; set; }

        public DbSet<WeaponFamily> WeaponFamilies { get; set; }

        public DbSet<AmmoType> AmmoTypes { get; set; }

        public DbSet<AmmoOption> AmmoOptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemBase>().UseTpcMappingStrategy();

            modelBuilder.Entity<Weapon>(weapon =>
            {
                weapon.HasOne(r => r.WeaponFamily)
                    .WithMany(r => r.WeaponsInFamily)
                    .HasForeignKey(k => k.WeaponFamilyId)
                    .OnDelete(DeleteBehavior.Cascade);

                weapon.OwnsOne(x => x.StaminaCost, stamina =>
                {
                    stamina.Property(p => p.StaminaCostLight).HasColumnName("StaminaCostLight");
                    stamina.Property(p => p.StaminaCostHeavy).HasColumnName("StaminaCostHeavy");
                });

                weapon.OwnsOne(x => x.Stats, stats =>
                {
                    stats.Property(p => p.Damage).HasColumnName("Damage");
                    stats.Property(p => p.DropRange).HasColumnName("DropRange");
                    stats.Property(p => p.RateOfFire).HasColumnName("RateOfFire");
                    stats.Property(p => p.CycleTime).HasColumnName("CycleTime");
                    stats.Property(p => p.Spread).HasColumnName("Spread");
                    stats.Property(p => p.Sway).HasColumnName("Sway");
                    stats.Property(p => p.Recoil).HasColumnName("Recoil");
                    stats.Property(p => p.ReloadSpeed).HasColumnName("ReloadSpeed");
                    stats.Property(p => p.MuzzleVelocity).HasColumnName("MuzzleVelocity");
                });

                weapon.OwnsOne(x => x.AmmoCapacity, capacity =>
                {
                    capacity.Property(p => p.DefaultCapacity).HasColumnName("DefaultCapacity");
                    capacity.Property(p => p.MaxCapacity).HasColumnName("MaxCapacity");
                    capacity.Property(p => p.SpareRounds).HasColumnName("SpareRounds");
                });

            });

            modelBuilder.Entity<AmmoOption>(ammoOption =>
            {
                ammoOption.HasOne(r => r.Weapon)
                    .WithMany(r => r.AmmoOptions)
                    .HasForeignKey(k => k.WeaponId)
                    .OnDelete(DeleteBehavior.Cascade);

                ammoOption.HasOne(r => r.AmmoType)
                    .WithMany()
                    .HasForeignKey(k => k.AmmoTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                ammoOption.HasIndex(i => new { i.WeaponId, i.AmmoTypeId }).IsUnique();

                ammoOption.OwnsOne(x => x.StatsOverride, stats =>
                {
                    stats.Property(p => p.DamageOverride).HasColumnName("DamageOverride");
                    stats.Property(p => p.DropRangeOverride).HasColumnName("DropRangeOverride");
                    stats.Property(p => p.RateOfFireOverride).HasColumnName("RateOfFireOverride");
                    stats.Property(p => p.CycleTimeOverride).HasColumnName("CycleTimeOverride");
                    stats.Property(p => p.SpreadOverride).HasColumnName("SpreadOverride");
                    stats.Property(p => p.SwayOverride).HasColumnName("SwayOverride");
                    stats.Property(p => p.RecoilOverride).HasColumnName("RecoilOverride");
                    stats.Property(p => p.ReloadSpeedOverride).HasColumnName("ReloadSpeedOverride");
                    stats.Property(p => p.MuzzleVelocityOverride).HasColumnName("MuzzleVelocityOverride");
                });
            });
        }

        public override int SaveChanges()
        {
            //this.ApplyAuditData();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //this.ApplyAuditData();

            return await base.SaveChangesAsync(cancellationToken);
        }

        /* This code is never reached, will remain here when it's time to implement auditing. */
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