using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace News.Database.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagArticles",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagArticles", x => new { x.ArticlesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_TagArticles_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagArticles_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6295), "Rick", "Sanchez", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6295) },
                    { 2, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297), "Morty", "Smith", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297) },
                    { 3, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6297), "Miyamoto", "Musashi", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6298) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6278), "Business", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6279) },
                    { 2, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6283), "Technology", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6283) },
                    { 3, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6284), "Culture", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6284) },
                    { 4, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6285), "Health", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6285) },
                    { 5, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6286), "General News", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6286) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6289), "breaking news", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6290) },
                    { 2, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6291), "war", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6292) },
                    { 3, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6292), "lmao", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293) },
                    { 4, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293), "sick", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6293) }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Text", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6300), "Now eldest new tastes plenty mother called misery get. Longer excuse for county nor except met its things. Narrow enough sex moment desire are. Hold who what come that seen read age its. Contained or estimable earnestly so perceived. Imprudence he in sufficient cultivated. Delighted promotion improving acuteness an newspaper offending he. Misery in am secure theirs giving an. Design on longer thrown oppose am.", "Article 1", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6300) },
                    { 2, 2, 2, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6302), "Carried nothing on am warrant towards. Polite in of in oh needed itself silent course. Assistance travelling so especially do prosperous appearance mr no celebrated. Wanted easily in my called formed suffer. Songs hoped sense as taken ye mirth at. Believe fat how six drawing pursuit minutes far. Same do seen head am part it dear open to. Whatever may scarcely judgment had.", "Article 2", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6302) },
                    { 3, 3, 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6303), "Society excited by cottage private an it esteems. Fully begin on by wound an. Girl rich in do up or both. At declared in as rejoiced of together. He impression collecting delightful unpleasant by prosperous as on. End too talent she object mrs wanted remove giving.", "Article 3", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6303) },
                    { 4, 1, 4, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6304), "Is post each that just leaf no. He connection interested so we an sympathize advantages. To said is it shed want do. Occasional middletons everything so to. Have spot part for his quit may. Enable it is square my an regard. Often merit stuff first oh up hills as he. Servants contempt as although addition dashwood is procured. Interest in yourself an do of numerous feelings cheerful confined.", "Article 4", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6304) },
                    { 5, 2, 1, new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6305), "Is post each that just leaf no. He connection interested so we an sympathize advantages. To said is it shed want do. Occasional middletons everything so to. Have spot part for his quit may. Enable it is square my an regard. Often merit stuff first oh up hills as he. Servants contempt as although addition dashwood is procured. Interest in yourself an do of numerous feelings cheerful confined.", "Article 5", new DateTime(2022, 5, 18, 21, 14, 37, 935, DateTimeKind.Utc).AddTicks(6305) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TagArticles_TagsId",
                table: "TagArticles",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagArticles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
