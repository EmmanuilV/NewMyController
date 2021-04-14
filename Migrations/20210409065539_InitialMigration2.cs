using Microsoft.EntityFrameworkCore.Migrations;

namespace MyController.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items");

            migrationBuilder.AlterColumn<int>(
                name: "todo_list_id",
                table: "todo_items",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items",
                column: "todo_list_id",
                principalTable: "todo_lists",
                principalColumn: "todo_list_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items");

            migrationBuilder.AlterColumn<int>(
                name: "todo_list_id",
                table: "todo_items",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items",
                column: "todo_list_id",
                principalTable: "todo_lists",
                principalColumn: "todo_list_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
