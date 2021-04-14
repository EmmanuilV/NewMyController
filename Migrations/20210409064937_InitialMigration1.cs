using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyController.Migrations
{
    public partial class InitialMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "todo_items",
                newName: "todo_item_id");

            migrationBuilder.AddColumn<int>(
                name: "todo_list_id",
                table: "todo_items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "todo_lists",
                columns: table => new
                {
                    todo_list_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_todo_lists", x => x.todo_list_id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_todo_items_todo_list_id",
                table: "todo_items",
                column: "todo_list_id");

            migrationBuilder.AddForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items",
                column: "todo_list_id",
                principalTable: "todo_lists",
                principalColumn: "todo_list_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_todo_items_todo_lists_todo_list_id",
                table: "todo_items");

            migrationBuilder.DropTable(
                name: "todo_lists");

            migrationBuilder.DropIndex(
                name: "ix_todo_items_todo_list_id",
                table: "todo_items");

            migrationBuilder.DropColumn(
                name: "todo_list_id",
                table: "todo_items");

            migrationBuilder.RenameColumn(
                name: "todo_item_id",
                table: "todo_items",
                newName: "id");
        }
    }
}
