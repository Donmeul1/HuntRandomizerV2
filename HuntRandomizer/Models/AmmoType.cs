namespace HuntRandomizer.Models
{
    public class AmmoType
    {
        protected AmmoType() { }
        public AmmoType(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; } = null!;

        public string Description { get; protected set; } = null!;
    }
}
