using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_TODO_List.Migrations
{
    /// <inheritdoc />
    public partial class AddToDoItemCreatedAtDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ToDoItems",
                type: "timestamp without time zone",
                nullable: false,
                defaultValueSql: "now()::timestamp",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "ToDoItems",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldDefaultValueSql: "now()::timestamp");
        }
    }
}
