using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PyPosApi.Migrations
{
    /// <inheritdoc />
    public partial class createAllDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserSchemes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "UserSchemes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BoxsCuts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TypeCut = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxsCuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoxsCuts_UserSchemes_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    INE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    ListBlack = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Horizontal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vertical = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shelf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTypeSale = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdArticleCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdProvider = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_CategoryArticles_IdArticleCategory",
                        column: x => x.IdArticleCategory,
                        principalTable: "CategoryArticles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Providers_IdProvider",
                        column: x => x.IdProvider,
                        principalTable: "Providers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_TypeSales_IdTypeSale",
                        column: x => x.IdTypeSale,
                        principalTable: "TypeSales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleSales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdArticle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleSales_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleSales_Clients_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleSales_UserSchemes_IdUser",
                        column: x => x.IdUser,
                        principalTable: "UserSchemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTrusteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdArticle = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTrusteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleTrusteds_Articles_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTrusteds_Clients_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticlePayments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    IdArticleTrusted = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticlePayments_ArticleTrusteds_IdArticleTrusted",
                        column: x => x.IdArticleTrusted,
                        principalTable: "ArticleTrusteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePayments_IdArticleTrusted",
                table: "ArticlePayments",
                column: "IdArticleTrusted");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdArticleCategory",
                table: "Articles",
                column: "IdArticleCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdProvider",
                table: "Articles",
                column: "IdProvider");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdTypeSale",
                table: "Articles",
                column: "IdTypeSale");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSales_IdArticle",
                table: "ArticleSales",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSales_IdCliente",
                table: "ArticleSales",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSales_IdUser",
                table: "ArticleSales",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTrusteds_IdClient",
                table: "ArticleTrusteds",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_BoxsCuts_IdUser",
                table: "BoxsCuts",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlePayments");

            migrationBuilder.DropTable(
                name: "ArticleSales");

            migrationBuilder.DropTable(
                name: "BoxsCuts");

            migrationBuilder.DropTable(
                name: "ArticleTrusteds");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "CategoryArticles");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "TypeSales");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserSchemes");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserSchemes");
        }
    }
}
