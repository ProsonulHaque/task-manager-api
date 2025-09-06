using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class SetDefaultValueForCreateDateColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "user_tasks",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() at time zone 'utc'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "statuses",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() at time zone 'utc'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "user_tasks",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() at time zone 'utc'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_date",
                schema: "public",
                table: "statuses",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() at time zone 'utc'");
        }
    }
}
