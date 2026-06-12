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


        #region Audit fields

        public bool Deleted { get; internal set; }

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

        public void ValidateConstruction(ItemInfo info, MeleeInfo meleeInfo)
        {
            ArgumentNullException.ThrowIfNull(info);
            ArgumentNullException.ThrowIfNull(meleeInfo);

            if (String.IsNullOrEmpty(info.Name))
                throw new ArgumentException("Name cannot be empty.", nameof(info.Name));

            if (String.IsNullOrEmpty(info.Description))
                throw new ArgumentException("Description cannot be empty.", nameof(info.Description));
                

            if (info.Cost < 0)
                throw new ArgumentOutOfRangeException("Cost cannot be negative.", nameof(info.Cost));
        }

        #endregion
    }
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