using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "create_date",
                schema: "public",
                table: "user_tasks",
                newName: "create_date_utc");

            migrationBuilder.RenameColumn(
                name: "create_date",
                schema: "public",
                table: "statuses",
                newName: "create_date_utc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "create_date_utc",
                schema: "public",
                table: "user_tasks",
                newName: "create_date");

            migrationBuilder.RenameColumn(
                name: "create_date_utc",
                schema: "public",
                table: "statuses",
                newName: "create_date");
        }
    }
}
