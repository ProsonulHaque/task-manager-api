using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace task_manager_api.Migrations
{
    /// <inheritdoc />
    public partial class CreatedStatusIdColumnWithTypeInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status_id",
                schema: "public",
                table: "user_tasks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "status_id",
                schema: "public",
                table: "statuses",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
