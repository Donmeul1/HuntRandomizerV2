using System.ComponentModel.DataAnnotations.Schema;

namespace HuntRandomizer.Models
{
    public class AmmoOption
    {
        protected AmmoOption() { } 
        public AmmoOption(AmmoScarcity scarcity, Weapon weapon, AmmoType ammoType)
        {
            Scarcity = scarcity;
            Weapon = weapon;
            WeaponId = weapon.Id;
            AmmoType = ammoType;
            AmmoTypeId = ammoType.Id;
        }

        public int Id { get; protected set; }

        public AmmoScarcity Scarcity { get; protected set; }


        [ForeignKey(nameof(WeaponId))]
        public int WeaponId { get; protected set; }
        public Weapon Weapon { get; protected set; } = null!;


        [ForeignKey(nameof(AmmoTypeId))]
        public int AmmoTypeId { get; protected set; }
        public AmmoType AmmoType { get; protected set; } = null!;
    }

    public enum AmmoScarcity : byte
    {
        Default = 1,
        Scarce = 2
    }
}