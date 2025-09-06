using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreateDateColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "user_tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "statuses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "create_date",
                schema: "public",
                table: "user_tasks");

            migrationBuilder.DropColumn(
                name: "create_date",
                schema: "public",
                table: "statuses");
        }
    }
}
