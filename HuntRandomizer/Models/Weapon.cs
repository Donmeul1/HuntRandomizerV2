using HuntRandomizer.Models.Records;
using Microsoft.EntityFrameworkCore;

namespace HuntRandomizer.Models
{
    public class Weapon : ItemBase
    {
        protected Weapon() { AmmoOptions = new List<AmmoOption>(); }

        public Weapon(WeaponInfo weaponInfo, ItemInfo itemInfo, MeleeInfo meleeInfo, StaminaCost? staminaInfo) 
            : base(itemInfo, meleeInfo, ItemType.Weapon, staminaInfo)
        {
            ArgumentNullException.ThrowIfNull(weaponInfo, nameof(weaponInfo));

            Stats = weaponInfo.Stats;
            SlotSize = weaponInfo.SlotSize;
            AmmoClass = weaponInfo.AmmoClass;
            AmmoCapacity = weaponInfo.Capacity;
            WeaponFamily = weaponInfo.WeaponFamily;

            AmmoOptions = new List<AmmoOption>();
        }

        public int WeaponFamilyId { get; protected set; }
        public WeaponFamily WeaponFamily { get; protected set; } = null!; 

        public WeaponStats Stats { get; protected set; } = null!;

        public SlotSize SlotSize { get; protected set; }

        public AmmoClass AmmoClass { get; protected set; }

        public AmmoCapacity AmmoCapacity { get; protected set; } = null!;

        public ICollection<AmmoOption> AmmoOptions { get; protected set; }

        public void AddAmmoOption(AmmoAvailability availability, AmmoType ammoType, WeaponStatsOverride? statsOverride = null)
        {
            ArgumentNullException.ThrowIfNull(ammoType);

            if (AmmoOptions.Any(option => option.AmmoType == ammoType))
                throw new InvalidOperationException($"{Name} already has {ammoType.Name} as custom ammo.");

            AmmoOptions.Add(new AmmoOption(availability, this, ammoType, statsOverride));
        }
    }

    public enum SlotSize : byte
    {
        Size1 = 1, 
        Size2 = 2,
        Size3 = 3,
        Size4 = 4,
        Size5 = 5
    }

    public enum AmmoClass : byte
    {
        Compact = 1,
        Medium = 2,
        Long = 3,
        SpecialLong = 4
    }
}