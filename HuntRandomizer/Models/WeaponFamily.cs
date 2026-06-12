namespace HuntRandomizer.Models
{
    public class WeaponFamily
    {
        protected WeaponFamily() { }

        public WeaponFamily(string name, string description) :this()
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (String.IsNullOrEmpty(description))
                throw new ArgumentException("Description can not be empty.", nameof(description));

            Name = name;
            Description = description;
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;


        public ICollection<Weapon> WeaponsInFamily { get; set; } = new List<Weapon>();
    }
}