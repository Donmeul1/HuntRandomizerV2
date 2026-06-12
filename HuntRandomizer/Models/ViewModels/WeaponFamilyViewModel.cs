namespace HuntRandomizer.Models.ViewModels
{
    public class WeaponFamilyViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Weapon>? WeaponsInFamily { get; set; }
    }
}
