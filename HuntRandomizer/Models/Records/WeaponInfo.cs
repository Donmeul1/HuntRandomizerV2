namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponInfo
    {
        public WeaponInfo(WeaponStats weaponStats, SlotSize slotSize, AmmoClass ammoClass, AmmoCapacity ammoCapacity)
        {
            ArgumentNullException.ThrowIfNull(weaponStats);
            ArgumentNullException.ThrowIfNull(ammoCapacity);

            Stats = weaponStats;
            SlotSize = slotSize;
            AmmoClass = ammoClass;
            Capacity = ammoCapacity;
        }

        public WeaponStats Stats { get; init; }
        
        public SlotSize SlotSize { get; init; }

        public AmmoClass AmmoClass { get; init; }

        public AmmoCapacity Capacity { get; init; }
    }
}