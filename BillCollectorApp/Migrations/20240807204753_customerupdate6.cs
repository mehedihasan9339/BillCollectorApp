using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BillCollectorApp.Migrations
{
    /// <inheritdoc />
    public partial class customerupdate6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "paymentDate",
                table: "BillInfos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paymentDate",
                table: "BillInfos");
        }
    }
}
