using HuntRandomizer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuntRandomizer.Runtime_Models
{
    [NotMapped]
    public class Loadout
    {
        private const int MaxEquipItems = 4;
        private readonly List<Tool> _tools;
        private readonly List<Consumable> _consumables;


        public Loadout(Weapon? primaryWeapon = null, Weapon? secondaryWeapon = null, List<Tool>? tools = null, List<Consumable>? consumables = null, bool hasQuartermaster = false)
        {
            this.PrimaryWeapon = primaryWeapon;
            this.SecondaryWeapon = secondaryWeapon;
            this._tools = tools?.ToList() ?? [];
            this._consumables = consumables?.ToList() ?? [];

            if(PrimaryWeapon != null && SecondaryWeapon != null)
            {
                int allowedSize = hasQuartermaster ? 6 : 5;
                if (((int)PrimaryWeapon.SlotSize + (int)SecondaryWeapon.SlotSize) > allowedSize)
                {
                    throw new ArgumentOutOfRangeException($"Total slot size can't be more than {allowedSize}");
                }
            }
            

            if (_tools.Count > MaxEquipItems) throw new ArgumentOutOfRangeException(nameof(tools), "Tools can't be more than 4.");
            if (_consumables.Count > MaxEquipItems) throw new ArgumentOutOfRangeException(nameof(consumables), "Consumables can't be more than 4.");
        }

        public Weapon? PrimaryWeapon { get; set; }
        public Weapon? SecondaryWeapon { get; set; }

        public IReadOnlyList<Tool> Tools => _tools.AsReadOnly();
        public IReadOnlyList<Consumable> Consumables => _consumables.AsReadOnly();

        public bool HasQuartermaster { get; set; }

        //control methods
        public void AddTool(Tool tool)
        {
            if (_tools.Count >= MaxEquipItems) throw new InvalidOperationException("Can't have more than 4 tools.");
            _tools.Add(tool);
        }

        public bool RemoveTool(Tool tool)
        {
            return _tools.Remove(tool);
        }

        public void ReplaceTool(int index, Tool tool)
        {
            _tools[index] = tool;
        }

        public void AddConsumable(Consumable consumable)
        {
            if (_consumables.Count() >= 4) throw new InvalidOperationException("Can't have more than 4 consumables.");
            _consumables.Add(consumable);
        }

        public bool RemoveConsumable(Consumable consumable)
        {
            return _consumables.Remove(consumable);
        }

        public void ReplaceConsumable(int index, Consumable consumable)
        {
            _consumables[index] = consumable;
        }


        //Calculated properties.
        public int WeaponSlotsUsed => ((int?)PrimaryWeapon?.SlotSize ?? 0) + ((int?)SecondaryWeapon?.SlotSize ?? 0);

        public int TotalTools => this._tools.Count;

        public int TotalConsumables => this._consumables.Count;
    }
}
