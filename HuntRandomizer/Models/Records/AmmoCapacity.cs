namespace HuntRandomizer.Models.Records
{
    public sealed record AmmoCapacity
    {
        public AmmoCapacity(int defaultCapacity, int maxCapacity, int spareRounds)
        {
            if (defaultCapacity < 1 || defaultCapacity > 20)
                throw new ArgumentOutOfRangeException(nameof(defaultCapacity), "Base ammo capacity must be between 1 and 20.");

            if (maxCapacity < 1 || maxCapacity > 20)
                throw new ArgumentOutOfRangeException(nameof(maxCapacity), "Max ammo capacity must be between 1 and 20.");

            if (maxCapacity < defaultCapacity)
                throw new ArgumentOutOfRangeException(nameof(maxCapacity), "Maximum capacity can not be lower than default capacty.");

            if (spareRounds <= 0 || spareRounds > 50)
                throw new ArgumentOutOfRangeException(nameof(spareRounds), "Spare ammo must be between 0 and 50");

            DefaultCapacity = defaultCapacity;
            MaxCapacity = maxCapacity;
            SpareRounds = spareRounds;
        }


        public int DefaultCapacity { get; init; }

        public int MaxCapacity { get; init; }

        public int SpareRounds { get; init; }

        public int TopOffAmount { get { return this.MaxCapacity - this.DefaultCapacity; } }


        public override string ToString()
        {
            return TopOffAmount > 0 ? $"{DefaultCapacity}+{TopOffAmount}/{SpareRounds}" : $"{MaxCapacity}/{SpareRounds}";
        }
    }
}