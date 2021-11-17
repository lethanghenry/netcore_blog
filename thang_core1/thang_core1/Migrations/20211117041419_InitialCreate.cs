using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace thang_core1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    loai = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    trangThai = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    viTri = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    motangan = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    chitiet = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ngayPublic = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
