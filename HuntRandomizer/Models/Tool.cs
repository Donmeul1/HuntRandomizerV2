using HuntRandomizer.Models.Records;

namespace HuntRandomizer.Models
{
    public class Tool : ItemBase
    {
        public Tool(ToolInfo toolInfo, ItemInfo info, MeleeInfo meleeInfo, StaminaCost? staminaInfo = null) 
            : base(info, meleeInfo, ItemType.Tool, staminaInfo)
        {
            Charges = toolInfo.Charges;
            Damage = toolInfo.Damage;
            DropRange = toolInfo.DropRange;
            MuzzleVelocity = toolInfo.MuzzleVelocity;
            Spread = toolInfo.Spread;
            ThrowRange = toolInfo.ThrowRange;
        }

        public int Charges { get; set; }

        public int? Damage { get; set; }

        public int? DropRange { get; set; }

        public int? MuzzleVelocity { get; set; }

        public int? Spread { get; set; }

        public int? ThrowRange { get; set; }
    }
}
