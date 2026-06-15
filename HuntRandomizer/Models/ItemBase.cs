using HuntRandomizer.Models.Records;
using System.ComponentModel.DataAnnotations;

namespace HuntRandomizer.Models
{
    public abstract class ItemBase
    {
        protected ItemBase() { }
        protected ItemBase(ItemInfo info, MeleeInfo meleeInfo, ItemType type, StaminaCost? staminaInfo = null)
        {
            ValidateConstruction(info, meleeInfo); 

            Name = info.Name;
            Description = info.Description;    
            Cost = info.Cost;
            BloodlineUlockLevel = info.BloodlineUnlockLevel;
            MeleeDamageLight = meleeInfo.MeleeDamageLight;
            MeleeDamageHeavy = meleeInfo.MeleeDamageHeavy;
            MeleeDamageLightType = meleeInfo.MeleeTypeLight;
            MeleeDamageHeavyType = meleeInfo.MeleeTypeHeavy;
            Type = type;
            StaminaCost = staminaInfo;
        }

        public int Id { get; protected set; }

        public string Name { get; protected set; } = null!;

        public string Description { get; protected set; } = null!;

        [Range(0, 1250)]
        public int Cost { get; protected set; }

        public int MeleeDamageLight { get; protected set; }

        public int MeleeDamageHeavy { get; protected set; }

        public MeleeType MeleeDamageLightType { get; protected set; }

        public MeleeType MeleeDamageHeavyType { get; protected set; }

        public StaminaCost? StaminaCost { get; protected set; }

        public ItemType Type { get; protected set; }

        public byte BloodlineUlockLevel { get; set; } = 0;

        #region Audit fields

        public bool Deleted { get; protected set; }

        public string? DeletedBy { get; internal set; } //populate only with user id when deleted.

        public DateTime? CreatedAt { get; internal set; }

        public DateTime? ChangedAt { get; internal set; }

        public DateTime? DeletedAt { get; internal set; }

        #endregion

        #region HelperMethods

        public void Delete()
        {
            this.Deleted = true;
            this.DeletedAt = DateTime.UtcNow;
        }

        public void Restore(bool clearDeletedAt = true)
        {
            this.Deleted = false;
            if (clearDeletedAt) { this.DeletedAt = null; }
        }

        protected static void ValidateConstruction(ItemInfo info, MeleeInfo meleeInfo)
        {
            ArgumentNullException.ThrowIfNull(info);
            ArgumentNullException.ThrowIfNull(meleeInfo);

            if (String.IsNullOrWhiteSpace(info.Name))
                throw new ArgumentException("Name cannot be empty.", nameof(info));

            if (String.IsNullOrWhiteSpace(info.Description))
                throw new ArgumentException("Description cannot be empty.", nameof(info));
                
            if (info.Cost < 0 || info.Cost > 1250)
                throw new ArgumentOutOfRangeException(nameof(info), "Cost must be between 0 and 1250.");

            if (meleeInfo.MeleeDamageHeavy < 0 || meleeInfo.MeleeDamageLight < 0)
                throw new ArgumentOutOfRangeException(nameof(meleeInfo), "Melee damage can't be negative.");
        }

        #endregion
    }
    public enum ItemType : byte
    {
        Weapon = 1,
        Tool = 2,
        Consumable = 3
    }

    public enum MeleeType : byte
    {
        Blunt = 1,
        Piercing = 2,
        Rending = 3
    }
}