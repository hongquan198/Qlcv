using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyTaiLieu.Repository.Migrations
{
    public partial class Migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "NVARCHAR(30)", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    Password = table.Column<string>(type: "NVARCHAR(20)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    RoleId = table.Column<string>(type: "VARCHAR(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accountid", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "NumberDoc",
                columns: table => new
                {
                    NumberDocCode = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NumberDocName = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_numberDoc", x => x.NumberDocCode);
                });

            migrationBuilder.CreateTable(
                name: "PlaceDoc",
                columns: table => new
                {
                    PlaceDocId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceDocName = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_PlaceDoc", x => x.PlaceDocId);
                });

            migrationBuilder.CreateTable(
                name: "TypeDoc",
                columns: table => new
                {
                    TypeDocId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeDocName = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_TypeDoc", x => x.TypeDocId);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Signer = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    ApprovedBy = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    NumberPage = table.Column<int>(type: "INT", nullable: false),
                    NumberSymbols = table.Column<string>(type: "NVARCHAR(40)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Abstract = table.Column<string>(type: "NVARCHAR(500)", nullable: true),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Receive = table.Column<string>(type: "NVARCHAR(40)", nullable: true),
                    NumberFrom = table.Column<int>(type: "INT", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Sender = table.Column<string>(type: "NVARCHAR(40)", nullable: true),
                    NumberGo = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<int>(type: "INT", nullable: false),
                    PlaceDocId = table.Column<int>(type: "INT", nullable: false),
                    NumberDocCode = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    TypeDocId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "fk_document_number",
                        column: x => x.NumberDocCode,
                        principalTable: "NumberDoc",
                        principalColumn: "NumberDocCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_document_place",
                        column: x => x.PlaceDocId,
                        principalTable: "PlaceDoc",
                        principalColumn: "PlaceDocId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_document_type",
                        column: x => x.TypeDocId,
                        principalTable: "TypeDoc",
                        principalColumn: "TypeDocId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_NumberDocCode",
                table: "Document",
                column: "NumberDocCode");

            migrationBuilder.CreateIndex(
                name: "IX_Document_PlaceDocId",
                table: "Document",
                column: "PlaceDocId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_TypeDocId",
                table: "Document",
                column: "TypeDocId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "NumberDoc");

            migrationBuilder.DropTable(
                name: "PlaceDoc");

            migrationBuilder.DropTable(
                name: "TypeDoc");
        }
    }
}
