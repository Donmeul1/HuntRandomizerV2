using HuntRandomizer.Models.Records;
using Microsoft.Identity.Client;

namespace HuntRandomizer.Models
{
    public class Consumable : ItemBase
    {
        protected Consumable() { }

        public Consumable(ConsumableInfo consumableInfo, ItemInfo info, MeleeInfo meleeInfo, StaminaCost? staminaInfo) 
            : base(info, meleeInfo, ItemType.Consumable, staminaInfo)
        {
            ArgumentNullException.ThrowIfNull(consumableInfo, nameof(consumableInfo));

            CausesDamage = consumableInfo.CausesDamage;
            HasEffect = consumableInfo.HasEffect;
            ThrowRange = consumableInfo.ThrowRange;
            FuseTimer = consumableInfo.FuseTimer;
            EffectRadius = consumableInfo.EffectRadius;
            EffectDuration = consumableInfo.EffectDuration;
        }

        public bool CausesDamage { get; set; }

        public bool HasEffect { get; set; }

        public int? ThrowRange { get; set; }

        public int? FuseTimer { get; set; }

        public int? EffectRadius { get; set; }

        public int? EffectDuration { get; set; }
    }
}
