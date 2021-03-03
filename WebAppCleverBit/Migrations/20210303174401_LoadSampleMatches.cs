using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAppCleverBit.Migrations
{
    public partial class LoadSampleMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Match",
                columns: new[] { "MatchID", "ExpiryDate" },
                values: new object[,]
                {
                    { 1, DateTime.Now.AddHours(1) },
                    { 2, DateTime.Now.AddHours(2) },
                    { 3, DateTime.Now.AddHours(3) },
                    { 4, DateTime.Now.AddHours(4) },
                    { 5, DateTime.Now.AddHours(5) },
                    { 6, DateTime.Now.AddHours(6) },
                    { 7, DateTime.Now.AddHours(7) },
                    { 8, DateTime.Now.AddHours(8) },
                    { 9, DateTime.Now.AddHours(9) },
                    { 10, DateTime.Now.AddHours(10) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Match",
                keyColumn: "MatchID",
                keyValue: 10);
        }
    }
}
