﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NexaWorks.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OSs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Versions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductKeyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versions_Products_ProductKeyId",
                        column: x => x.ProductKeyId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Version_OS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionKeyId = table.Column<int>(type: "int", nullable: false),
                    OSKeyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version_OS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Version_OS_OSs_OSKeyId",
                        column: x => x.OSKeyId,
                        principalTable: "OSs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Version_OS_Versions_VersionKeyId",
                        column: x => x.VersionKeyId,
                        principalTable: "Versions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreat = table.Column<DateOnly>(type: "date", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    DateResolve = table.Column<DateOnly>(type: "date", nullable: true),
                    ResolveDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssociatedVersionOSId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Version_OS_AssociatedVersionOSId",
                        column: x => x.AssociatedVersionOSId,
                        principalTable: "Version_OS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AssociatedVersionOSId",
                table: "Tickets",
                column: "AssociatedVersionOSId");

            migrationBuilder.CreateIndex(
                name: "IX_Version_OS_OSKeyId",
                table: "Version_OS",
                column: "OSKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Version_OS_VersionKeyId",
                table: "Version_OS",
                column: "VersionKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_Versions_ProductKeyId",
                table: "Versions",
                column: "ProductKeyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Version_OS");

            migrationBuilder.DropTable(
                name: "OSs");

            migrationBuilder.DropTable(
                name: "Versions");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
