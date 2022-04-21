using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppFinal.Migrations
{
    public partial class editMessageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_FromUserId",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "FromUserId",
                table: "Message",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_FromUserId",
                table: "Message",
                newName: "IX_Message_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "FromUser",
                table: "Message",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ApplicationUserId",
                table: "Message",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ApplicationUserId",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "FromUser",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Message",
                newName: "FromUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ApplicationUserId",
                table: "Message",
                newName: "IX_Message_FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_FromUserId",
                table: "Message",
                column: "FromUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
