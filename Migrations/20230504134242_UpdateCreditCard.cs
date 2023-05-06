using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCreditCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_CreditCardEntity_CreditCardId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCardEntity",
                table: "CreditCardEntity");

            migrationBuilder.RenameTable(
                name: "CreditCardEntity",
                newName: "CreditCards");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_CreditCards_CreditCardId",
                table: "UserProfiles",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_CreditCards_CreditCardId",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                newName: "CreditCardEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCardEntity",
                table: "CreditCardEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_CreditCardEntity_CreditCardId",
                table: "UserProfiles",
                column: "CreditCardId",
                principalTable: "CreditCardEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
