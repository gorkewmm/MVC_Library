using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebUygulamaProje.Migrations
{
    /// <inheritdoc />
    public partial class KitapTurleriVeKitaplarTablosuEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tanim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Yazar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitapTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapTurleri", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "KitapTurleri");
        }
    }
}
