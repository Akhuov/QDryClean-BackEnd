using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QDryClean.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updates_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_Charges_ChargeId",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_ChargeId",
                table: "ItemTypes");

            migrationBuilder.AlterColumn<int>(
                name: "ChargeId",
                table: "ItemTypes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ItemCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ChargeId",
                table: "ItemTypes",
                column: "ChargeId",
                unique: true,
                filter: "[ChargeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Charges_ChargeId",
                table: "ItemTypes",
                column: "ChargeId",
                principalTable: "Charges",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_Charges_ChargeId",
                table: "ItemTypes");

            migrationBuilder.DropIndex(
                name: "IX_ItemTypes_ChargeId",
                table: "ItemTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ItemCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ChargeId",
                table: "ItemTypes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypes_ChargeId",
                table: "ItemTypes",
                column: "ChargeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Charges_ChargeId",
                table: "ItemTypes",
                column: "ChargeId",
                principalTable: "Charges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
