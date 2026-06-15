using HuntRandomizer.Models;

namespace HuntRandomizer.ViewModels.WeaponFamilies
{
    public class ListWeaponFamiliesViewModel
    {
        public ListWeaponFamiliesViewModel(List<WeaponFamily> weaponFamilies)
        {
            ArgumentNullException.ThrowIfNull(weaponFamilies);

            this.WeaponFamilies = weaponFamilies;
        }

        public List<WeaponFamily> WeaponFamilies { get; set; }
    }
}