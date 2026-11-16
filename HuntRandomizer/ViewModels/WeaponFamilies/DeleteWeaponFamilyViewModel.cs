using HuntRandomizer.Models;

namespace HuntRandomizer.ViewModels.WeaponFamilies
{
    public class DeleteWeaponFamilyViewModel
    {
        public  DeleteWeaponFamilyViewModel() { }
        public DeleteWeaponFamilyViewModel(WeaponFamily family, bool cascade = false) 
        {
            this.WeaponFamily = family;
            this.CascadeDeleteWeapons = cascade;
        }

        public WeaponFamily WeaponFamily { get; set; }

        public bool CascadeDeleteWeapons { get; set; } = false;

        public List<Weapon> WeaponsInFamily()
        {
            return this.WeaponFamily.WeaponsInFamily.ToList();
        }
    }
}
