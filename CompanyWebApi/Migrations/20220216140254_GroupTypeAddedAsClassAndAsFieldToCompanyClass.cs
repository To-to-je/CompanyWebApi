using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyWebApi.Migrations
{
    public partial class GroupTypeAddedAsClassAndAsFieldToCompanyClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_GroupId",
                table: "Companies",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_GroupType_GroupId",
                table: "Companies",
                column: "GroupId",
                principalTable: "GroupType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_GroupType_GroupId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "GroupType");

            migrationBuilder.DropIndex(
                name: "IX_Companies_GroupId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Companies");
        }
    }
}
