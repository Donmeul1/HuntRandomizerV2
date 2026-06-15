using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuntRandomizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConsumableAndToolDataSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "BloodlineUnlockLevel",
                table: "Weapons",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemBaseSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageLight = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageHeavy = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageLightType = table.Column<byte>(type: "tinyint", nullable: false),
                    MeleeDamageHeavyType = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    BloodlineUnlockLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CausesDamage = table.Column<bool>(type: "bit", nullable: false),
                    HasEffect = table.Column<bool>(type: "bit", nullable: false),
                    ThrowRange = table.Column<int>(type: "int", nullable: true),
                    FuseTimer = table.Column<int>(type: "int", nullable: true),
                    EffectRadius = table.Column<int>(type: "int", nullable: true),
                    EffectDuration = table.Column<int>(type: "int", nullable: true),
                    StaminaCostLight = table.Column<int>(type: "int", nullable: true),
                    StaminaCostHeavy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [ItemBaseSequence]"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageLight = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageHeavy = table.Column<int>(type: "int", nullable: false),
                    MeleeDamageLightType = table.Column<byte>(type: "tinyint", nullable: false),
                    MeleeDamageHeavyType = table.Column<byte>(type: "tinyint", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    BloodlineUnlockLevel = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Charges = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: true),
                    DropRange = table.Column<int>(type: "int", nullable: true),
                    MuzzleVelocity = table.Column<int>(type: "int", nullable: true),
                    Spread = table.Column<int>(type: "int", nullable: true),
                    ThrowRange = table.Column<int>(type: "int", nullable: true),
                    StaminaCostLight = table.Column<int>(type: "int", nullable: true),
                    StaminaCostHeavy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropColumn(
                name: "BloodlineUnlockLevel",
                table: "Weapons");
        }
    }
}
