namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponInfo
    {
        public WeaponInfo(WeaponStats weaponStats, SlotSize slotSize, AmmoClass ammoClass, AmmoCapacity ammoCapacity, WeaponFamily weaponFamily)
        {
            ArgumentNullException.ThrowIfNull(weaponStats);
            ArgumentNullException.ThrowIfNull(ammoCapacity);
            ArgumentNullException.ThrowIfNull(weaponFamily);

            Stats = weaponStats;
            SlotSize = slotSize;
            AmmoClass = ammoClass;
            Capacity = ammoCapacity;
            WeaponFamily = weaponFamily;
        }

        public WeaponStats Stats { get; init; }
        
        public SlotSize SlotSize { get; init; }

        public AmmoClass AmmoClass { get; init; }

        public AmmoCapacity Capacity { get; init; }

        public WeaponFamily WeaponFamily { get; init; }
    }
}