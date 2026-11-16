using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HuntRandomizer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehaviours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOptions_AmmoTypes_AmmoTypeId",
                table: "AmmoOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_WeaponFamilies_WeaponFamilyId",
                table: "Weapons");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOptions_AmmoTypes_AmmoTypeId",
                table: "AmmoOptions",
                column: "AmmoTypeId",
                principalTable: "AmmoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_WeaponFamilies_WeaponFamilyId",
                table: "Weapons",
                column: "WeaponFamilyId",
                principalTable: "WeaponFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AmmoOptions_AmmoTypes_AmmoTypeId",
                table: "AmmoOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_WeaponFamilies_WeaponFamilyId",
                table: "Weapons");

            migrationBuilder.AddForeignKey(
                name: "FK_AmmoOptions_AmmoTypes_AmmoTypeId",
                table: "AmmoOptions",
                column: "AmmoTypeId",
                principalTable: "AmmoTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_WeaponFamilies_WeaponFamilyId",
                table: "Weapons",
                column: "WeaponFamilyId",
                principalTable: "WeaponFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
