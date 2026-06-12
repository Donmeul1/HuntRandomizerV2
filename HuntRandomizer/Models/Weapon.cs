using HuntRandomizer.Models.Records;

namespace HuntRandomizer.Models
{
    public class Weapon : ItemBase
    {
        protected Weapon() { }

        public Weapon(WeaponInfo weaponInfo, ItemInfo itemInfo, MeleeInfo meleeInfo, StaminaCost? staminaInfo) 
            : base(itemInfo, meleeInfo, ItemType.Weapon, staminaInfo)
        {

        }
        
        public SlotSize SlotSize { get; protected set; }

        public AmmoClass AmmoClass { get; protected set; }

        public AmmoCapacity AmmoCapcity { get; protected set; }

        public ICollection<AmmoOption> AmmoOptions { get; protected set; } = new List<AmmoOption>();


    }

    public enum SlotSize : byte
    {
        Size1 = 1, 
        Size2 = 2,
        Size3 = 3,
        Size4 = 4,
        Size5 = 5
    }

    public enum AmmoClass : byte
    {
        Compact = 1,
        Medium = 2,
        Long = 3,
        SpecialLong = 4
    }
}