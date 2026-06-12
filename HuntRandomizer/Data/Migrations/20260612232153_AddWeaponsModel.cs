using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuntRandomizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddWeaponsModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ItemBaseSequence");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AmmoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeaponFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponFamilies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
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
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeaponFamilyId = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    DropRange = table.Column<int>(type: "int", nullable: false),
                    RateOfFire = table.Column<int>(type: "int", nullable: false),
                    CycleTime = table.Column<float>(type: "real", nullable: false),
                    Spread = table.Column<float>(type: "real", nullable: false),
                    Sway = table.Column<float>(type: "real", nullable: false),
                    Recoil = table.Column<float>(type: "real", nullable: false),
                    ReloadSpeed = table.Column<float>(type: "real", nullable: false),
                    MuzzleVelocity = table.Column<int>(type: "int", nullable: false),
                    SlotSize = table.Column<byte>(type: "tinyint", nullable: false),
                    AmmoClass = table.Column<byte>(type: "tinyint", nullable: false),
                    DefaultCapacity = table.Column<int>(type: "int", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    SpareRounds = table.Column<int>(type: "int", nullable: false),
                    StaminaCostLight = table.Column<int>(type: "int", nullable: true),
                    StaminaCostHeavy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_WeaponFamilies_WeaponFamilyId",
                        column: x => x.WeaponFamilyId,
                        principalTable: "WeaponFamilies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AmmoOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Availability = table.Column<byte>(type: "tinyint", nullable: false),
                    DamageOverride = table.Column<int>(type: "int", nullable: true),
                    DropRangeOverride = table.Column<int>(type: "int", nullable: true),
                    RateOfFireOverride = table.Column<int>(type: "int", nullable: true),
                    CycleTimeOverride = table.Column<float>(type: "real", nullable: true),
                    SpreadOverride = table.Column<float>(type: "real", nullable: true),
                    SwayOverride = table.Column<float>(type: "real", nullable: true),
                    RecoilOverride = table.Column<float>(type: "real", nullable: true),
                    ReloadSpeedOverride = table.Column<float>(type: "real", nullable: true),
                    MuzzleVelocityOverride = table.Column<int>(type: "int", nullable: true),
                    WeaponId = table.Column<int>(type: "int", nullable: false),
                    AmmoTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmmoOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AmmoOptions_AmmoTypes_AmmoTypeId",
                        column: x => x.AmmoTypeId,
                        principalTable: "AmmoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmmoOptions_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AmmoOptions_AmmoTypeId",
                table: "AmmoOptions",
                column: "AmmoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AmmoOptions_WeaponId_AmmoTypeId",
                table: "AmmoOptions",
                columns: new[] { "WeaponId", "AmmoTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_WeaponFamilyId",
                table: "Weapons",
                column: "WeaponFamilyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmmoOptions");

            migrationBuilder.DropTable(
                name: "AmmoTypes");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "WeaponFamilies");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropSequence(
                name: "ItemBaseSequence");
        }
    }
}
