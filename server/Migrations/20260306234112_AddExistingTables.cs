using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFCSite.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddExistingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Baseline migration — tables already exist in the database.
        }

        private void _OriginalUp(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.CategoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Family", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RawPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Publish = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RawPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StyleSheet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CSSData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.StyleSheet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Markup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CategoryType_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Category_dbo.CategoryType_CategoryType_Id",
                        column: x => x.CategoryType_Id,
                        principalTable: "CategoryType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LongName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Family_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.BaseIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.BaseIngredient_dbo.Family_Family_Id",
                        column: x => x.Family_Id,
                        principalTable: "Family",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TagRawPost",
                columns: table => new
                {
                    Tag_Id = table.Column<int>(type: "int", nullable: false),
                    RawPost_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.TagRawPost", x => new { x.Tag_Id, x.RawPost_Id });
                    table.ForeignKey(
                        name: "FK_dbo.TagRawPost_dbo.RawPost_RawPost_Id",
                        column: x => x.RawPost_Id,
                        principalTable: "RawPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.TagRawPost_dbo.Tag_Tag_Id",
                        column: x => x.Tag_Id,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RawPostCategory",
                columns: table => new
                {
                    RawPost_Id = table.Column<int>(type: "int", nullable: false),
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.RawPostCategory", x => new { x.RawPost_Id, x.Category_Id });
                    table.ForeignKey(
                        name: "FK_dbo.RawPostCategory_dbo.Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.RawPostCategory_dbo.RawPost_RawPost_Id",
                        column: x => x.RawPost_Id,
                        principalTable: "RawPost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Family_Id",
                table: "BaseIngredient",
                column: "Family_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryType_Id",
                table: "Category",
                column: "CategoryType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "RawPostCategory",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RawPost_Id",
                table: "RawPostCategory",
                column: "RawPost_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RawPost_Id",
                table: "TagRawPost",
                column: "RawPost_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Id",
                table: "TagRawPost",
                column: "Tag_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Intentionally empty.
        }

        private void _OriginalDown(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseIngredient");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "RawPostCategory");

            migrationBuilder.DropTable(
                name: "StyleSheet");

            migrationBuilder.DropTable(
                name: "TagRawPost");

            migrationBuilder.DropTable(
                name: "Family");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "RawPost");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "CategoryType");
        }
    }
}
