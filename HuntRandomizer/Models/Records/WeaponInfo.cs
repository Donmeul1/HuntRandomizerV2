namespace HuntRandomizer.Models.Records
{
    public sealed record WeaponInfo
    {
        protected WeaponInfo() { }
        public WeaponInfo(AmmoCapacity ammoCapacity)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(ammoCapacity));

            Capacity = ammoCapacity;
        }

        public AmmoCapacity Capacity { get; set; }
    }
}
