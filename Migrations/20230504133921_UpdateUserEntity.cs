using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCardEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_CreditCardId",
                table: "UserProfiles",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_CreditCardEntity_CreditCardId",
                table: "UserProfiles",
                column: "CreditCardId",
                principalTable: "CreditCardEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_CreditCardEntity_CreditCardId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CreditCardEntity");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_CreditCardId",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "UserProfiles");
        }
    }
}
