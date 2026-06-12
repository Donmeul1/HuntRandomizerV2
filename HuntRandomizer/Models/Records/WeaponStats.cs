namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponStats
    {
        public int Damage { get; init; }

        public int DropRange { get; init; }

        public int RateOfFire { get; init; }

        public float CycleTime { get; init; }

        public float Spread { get; init; }

        public float Sway { get; init; }

        public float Recoil { get; init; }

        public float ReloadSpeed { get; init; }

        public int MuzzleVelocity { get; init; }


        public WeaponStats ApplyOverride(WeaponStatsOverride? statsOverride)
        {
            if(statsOverride == null)
            {
                return this;
            }

            return this with
            {
                Damage = statsOverride.Damage ?? Damage,
                DropRange = statsOverride.DropRange ?? DropRange,
                RateOfFire = statsOverride.RateOfFire ?? RateOfFire,
                CycleTime = statsOverride.CycleTime ?? CycleTime,
                Spread = statsOverride.Spread ?? Spread,
                Sway = statsOverride.Sway ?? Sway,
                Recoil = statsOverride.Recoil ?? Recoil,
                ReloadSpeed = statsOverride.ReloadSpeed ?? ReloadSpeed,
                MuzzleVelocity = statsOverride.MuzzleVelocity ?? MuzzleVelocity
            };
        }
    }
}
