using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class mig_Comment2_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments2",
                columns: table => new
                {
                    Comment2ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment2Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment2Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment2Status = table.Column<bool>(type: "bit", nullable: false),
                    Comment2Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment2UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image2Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments2", x => x.Comment2ID);
                });
        }
    }
}
