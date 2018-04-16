using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ListingTodos.Migrations
{
    public partial class AddDueDateToTodos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Todos",
                newName: "AddedOn");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DueOn",
                table: "Todos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueOn",
                table: "Todos");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "AddedOn",
                table: "Todos",
                newName: "Date");
        }
    }
}
