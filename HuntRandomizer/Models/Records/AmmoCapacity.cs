namespace HuntRandomizer.Models.Records
{
    public sealed record AmmoCapacity
    {
        protected AmmoCapacity() { }
        public AmmoCapacity(int ammoCapacityBase, int ammoCapacityMax, int ammoCapacitySpare)
        {
            if (ammoCapacityBase <= 0 || ammoCapacityBase > 20)
                throw new ArgumentOutOfRangeException(nameof(ammoCapacityBase), "Base ammo capacity must be between 0 and 20.");

            if (ammoCapacityMax <= 0 || ammoCapacityMax > 20)
                throw new ArgumentOutOfRangeException(nameof(ammoCapacityMax), "Max ammo capacity must be between 0 and 20.");

            if (ammoCapacitySpare <= 0 || ammoCapacitySpare > 50)
                throw new ArgumentOutOfRangeException(nameof(ammoCapacitySpare), "Spare ammo must be between 0 and 50");

            AmmoCapacityBase = ammoCapacityBase;
            AmmoCapacityMax = ammoCapacityMax;
            AmmoCapacitySpare = ammoCapacitySpare;
        }


        public int AmmoCapacityBase { get; set; }

        public int AmmoCapacityMax { get; set; }

        public int AmmoCapacitySpare { get; set; }
    }
}
