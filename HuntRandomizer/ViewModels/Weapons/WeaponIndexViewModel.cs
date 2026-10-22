using HuntRandomizer.Models;

namespace HuntRandomizer.ViewModels.Weapons
{
    public class WeaponIndexViewModel
    {
        public WeaponIndexViewModel(List<Weapon> weapons)
        {
            HasWeapons = true;
            NoWeaponsMessage = String.Empty;
            Weapons = weapons;

            if (Weapons == null || Weapons.Count == 0) 
            {
                HasWeapons = false;
                NoWeaponsMessage = "There are currently no weapons found in the database.";
            }
        }

        public List<Weapon>? Weapons { get; set; }

        public bool HasWeapons { get; set; }

        public string NoWeaponsMessage { get; set; }
    }
}
