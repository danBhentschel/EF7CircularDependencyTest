using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace EFTest.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    ChildId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ParentParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.ChildId);
                });
            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FavoriteChildChildId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.ParentId);
                    table.ForeignKey(
                        name: "FK_Parent_Child_FavoriteChildChildId",
                        column: x => x.FavoriteChildChildId,
                        principalTable: "Child",
                        principalColumn: "ChildId",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddForeignKey(
                name: "FK_Child_Parent_ParentParentId",
                table: "Child",
                column: "ParentParentId",
                principalTable: "Parent",
                principalColumn: "ParentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Parent_Child_FavoriteChildChildId", table: "Parent");
            migrationBuilder.DropTable("Child");
            migrationBuilder.DropTable("Parent");
        }
    }
}
