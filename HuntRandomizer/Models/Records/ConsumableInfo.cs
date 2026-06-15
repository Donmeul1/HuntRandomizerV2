namespace HuntRandomizer.Models.Records
{
    public sealed record ConsumableInfo(bool CausesDamage, bool HasEffect, int? ThrowRange, int? FuseTimer, 
        int? EffectRadius, int? EffectDuration);
}