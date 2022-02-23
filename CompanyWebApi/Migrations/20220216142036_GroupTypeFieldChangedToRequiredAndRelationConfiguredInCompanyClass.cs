using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyWebApi.Migrations
{
    public partial class GroupTypeFieldChangedToRequiredAndRelationConfiguredInCompanyClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_GroupType_GroupId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupType",
                table: "GroupType");

            migrationBuilder.RenameTable(
                name: "GroupType",
                newName: "GroupTypes");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Companies",
                newName: "GroupTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_GroupId",
                table: "Companies",
                newName: "IX_Companies_GroupTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "GroupTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTypes",
                table: "GroupTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_GroupTypes_GroupTypeId",
                table: "Companies",
                column: "GroupTypeId",
                principalTable: "GroupTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_GroupTypes_GroupTypeId",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTypes",
                table: "GroupTypes");

            migrationBuilder.RenameTable(
                name: "GroupTypes",
                newName: "GroupType");

            migrationBuilder.RenameColumn(
                name: "GroupTypeId",
                table: "Companies",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_GroupTypeId",
                table: "Companies",
                newName: "IX_Companies_GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "GroupType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupType",
                table: "GroupType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_GroupType_GroupId",
                table: "Companies",
                column: "GroupId",
                principalTable: "GroupType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
