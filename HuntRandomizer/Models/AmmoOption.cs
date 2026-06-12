using HuntRandomizer.Models.Records;

namespace HuntRandomizer.Models
{
    public class AmmoOption
    {
        protected AmmoOption() { } 
        public AmmoOption(AmmoAvailability availability, Weapon weapon, AmmoType ammoType, WeaponStatsOverride? statsOverride)
        {
            Availability = availability;
            Weapon = weapon;
            AmmoType = ammoType;
            StatsOverride = statsOverride;
        }

        public int Id { get; protected set; }

        public AmmoAvailability Availability { get; protected set; }

        public WeaponStatsOverride? StatsOverride { get; protected set; } = null!;


        public int WeaponId { get; protected set; }
        public Weapon Weapon { get; protected set; } = null!;


        public int AmmoTypeId { get; protected set; }
        public AmmoType AmmoType { get; protected set; } = null!;
        
        public WeaponStats GetEffectiveStats()
        {
            return Weapon.Stats.ApplyOverride(StatsOverride);
        }
    }

    public enum AmmoAvailability : byte
    {
        Default = 1,
        Buyable = 2,
        Scarce = 3
    }
}