namespace HuntRandomizer.Models.Records
{
    public sealed record ToolInfo(int Charges, int? Damage, int? DropRange, int? MuzzleVelocity,
        int? Spread, int? ThrowRange);
}
