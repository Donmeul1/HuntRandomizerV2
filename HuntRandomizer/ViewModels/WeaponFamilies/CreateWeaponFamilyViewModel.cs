using System.ComponentModel.DataAnnotations;

namespace HuntRandomizer.ViewModels.WeaponFamilies
{
    public class CreateWeaponFamilyViewModel
    {
        public CreateWeaponFamilyViewModel() { }

        public CreateWeaponFamilyViewModel(string name, string description)
        {
            Name = name;
            Description = description;
        }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
