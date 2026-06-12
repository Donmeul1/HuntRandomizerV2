namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponStats
    {
        public WeaponStats(int damage, int dropRange, int rateOfFire, float cycleTime, float spread, float sway, float recoil, float reloadSpeed, int velocity)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage), "Damage can not be negative.");

            if (dropRange < 0)
                throw new ArgumentOutOfRangeException(nameof(dropRange), "Drop range can not be negative.");

            if(rateOfFire < 0)
                throw new ArgumentOutOfRangeException(nameof(rateOfFire), "Rate of fire can not be negative.");

            if (cycleTime < 0)
                throw new ArgumentOutOfRangeException(nameof(cycleTime), "Cycle time can not be negative.");

            if (spread < 0)
                throw new ArgumentOutOfRangeException(nameof(spread), "Spread can not be negative.");

            if(sway < 0)
                throw new ArgumentOutOfRangeException(nameof(sway), "Sway can not be negative.");

            if (recoil < 0)
                throw new ArgumentOutOfRangeException(nameof(recoil), "Recoil can not be negative.");

            if (reloadSpeed < 0)
                throw new ArgumentOutOfRangeException(nameof(reloadSpeed), "Reload speed can not be negative.");

            if (velocity < 0)
                throw new ArgumentOutOfRangeException(nameof(velocity), "Muzzle velocity can not be negative.");

            Damage = damage;
            DropRange = dropRange;
            RateOfFire = rateOfFire;
            CycleTime = cycleTime;
            Spread = spread;
            Sway = sway;
            Recoil = recoil;
            ReloadSpeed = reloadSpeed;
            MuzzleVelocity = velocity; 

        }


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
