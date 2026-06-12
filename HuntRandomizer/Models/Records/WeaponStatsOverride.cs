namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponStatsOverride
    {
        public int? DamageOverride { get; init; }

        public int? DropRangeOverride { get; init; }

        public int? RateOfFireOverride { get; init; }

        public float? CycleTimeOverride { get; init; }

        public float? SpreadOverride { get; init; }

        public float? SwayOverride { get; init; }

        public float? RecoilOverride { get; init; }

        public float? ReloadSpeedOverride { get; init; }

        public int? MuzzleVelocityOverride { get; init; }
    }
}
