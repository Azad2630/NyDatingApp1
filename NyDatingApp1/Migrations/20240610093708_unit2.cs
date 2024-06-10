using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NyDatingApp1.Migrations
{
    /// <inheritdoc />
    public partial class unit2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Profiles_ProfileId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_ProfileId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProfileId",
                table: "Accounts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Profiles_ProfileId",
                table: "Accounts",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
