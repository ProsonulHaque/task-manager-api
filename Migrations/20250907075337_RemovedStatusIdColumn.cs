using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStatusIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_tasks_statuses_status_id",
                schema: "public",
                table: "user_tasks");

            migrationBuilder.DropIndex(
                name: "ix_user_tasks_status_id",
                schema: "public",
                table: "user_tasks");

            migrationBuilder.DropPrimaryKey(
                name: "pk_statuses",
                schema: "public",
                table: "statuses");

            migrationBuilder.DropColumn(
                name: "status_id",
                schema: "public",
                table: "user_tasks");

            migrationBuilder.DropColumn(
                name: "status_id",
                schema: "public",
                table: "statuses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "status_id",
                schema: "public",
                table: "user_tasks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "status_id",
                schema: "public",
                table: "statuses",
                type: "uuid",
                nullable: false,
                defaultValueSql: "uuid_generate_v4()");

            migrationBuilder.AddPrimaryKey(
                name: "pk_statuses",
                schema: "public",
                table: "statuses",
                column: "status_id");

            migrationBuilder.CreateIndex(
                name: "ix_user_tasks_status_id",
                schema: "public",
                table: "user_tasks",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_tasks_statuses_status_id",
                schema: "public",
                table: "user_tasks",
                column: "status_id",
                principalSchema: "public",
                principalTable: "statuses",
                principalColumn: "status_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
