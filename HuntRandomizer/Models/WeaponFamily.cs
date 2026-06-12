namespace HuntRandomizer.Models
{
    public class WeaponFamily
    {
        protected WeaponFamily() { }

        public WeaponFamily(string name) :this()
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;


        public ICollection<Weapon> WeaponsInFamily { get; set; } = new List<Weapon>();
    }
}
