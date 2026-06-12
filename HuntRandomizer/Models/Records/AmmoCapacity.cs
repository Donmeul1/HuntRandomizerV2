namespace HuntRandomizer.Models.Records
{
    public sealed record AmmoCapacity
    {
        protected AmmoCapacity() { }
        public AmmoCapacity(int @base, int max, int spare)
        {
            if (@base <= 0 || @base > 20)
                throw new ArgumentOutOfRangeException(nameof(@base), "Base ammo capacity must be between 0 and 20.");

            if (max <= 0 || max > 20)
                throw new ArgumentOutOfRangeException(nameof(max), "Max ammo capacity must be between 0 and 20.");

            if (spare <= 0 || spare > 50)
                throw new ArgumentOutOfRangeException(nameof(spare), "Spare ammo must be between 0 and 50");

            Base = @base;
            Max = max;
            Spare = spare;
        }


        public int Base { get; set; }

        public int Max { get; set; }

        public int Spare { get; set; }
    }
}
