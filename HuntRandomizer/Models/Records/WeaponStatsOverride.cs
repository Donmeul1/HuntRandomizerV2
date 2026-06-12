namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponStatsOverride
    {
        public int? Damage { get; init; }

        public int? DropRange { get; init; }

        public int? RateOfFire { get; init; }

        public float? CycleTime { get; init; }

        public float? Spread { get; init; }

        public float? Sway { get; init; }

        public float? Recoil { get; init; }

        public float? ReloadSpeed { get; init; }

        public int? MuzzleVelocity { get; init; }
    }
}
