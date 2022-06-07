using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Database.Migrations
{
    public partial class UpdateAuthorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Authors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8074), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8074) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8076), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8076) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8077), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8077) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8078), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8078) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8079), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8080) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Login", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8068), "Sanchez123", "123123", new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8068) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Login", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8070), "Master", "123123", new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8071) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Login", "Password", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8071), "Samurai", "123123", new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8072) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8048), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8049) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8051), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8051) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8052), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8053) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8053), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8054) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8054), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8055) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8059), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8059) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8063), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8063) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8064), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8064) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8065), new DateTime(2022, 5, 24, 6, 49, 34, 890, DateTimeKind.Utc).AddTicks(8065) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Login",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6300), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6300) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6302), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6302) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6303), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6303) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6304), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6304) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6305), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6305) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6295), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6295) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6298) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6278), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6279) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6283), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6283) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6284), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6284) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6285), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6285) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6286), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6286) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6289), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6290) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6291), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6292) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6292), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293), new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293) });
        }
    }
}
