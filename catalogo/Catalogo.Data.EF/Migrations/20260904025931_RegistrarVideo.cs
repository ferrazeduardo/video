using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalogo.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class RegistrarVideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoCastFilme",
                columns: table => new
                {
                    ID_VIDEO = table.Column<int>(type: "integer", nullable: false),
                    ID_CAST_FILME = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCastFilme", x => new { x.ID_CAST_FILME, x.ID_VIDEO });
                });

            migrationBuilder.CreateTable(
                name: "VideoCategoria",
                columns: table => new
                {
                    ID_VIDEO = table.Column<int>(type: "integer", nullable: false),
                    ID_CATEGORIA = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategoria", x => new { x.ID_CATEGORIA, x.ID_VIDEO });
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    Publicado = table.Column<bool>(type: "boolean", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duracao = table.Column<int>(type: "integer", nullable: false),
                    AnoLancamento = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ThumbCaminho = table.Column<string>(type: "text", nullable: true),
                    ThumbHalfCaminho = table.Column<string>(type: "text", nullable: true),
                    BannerCaminho = table.Column<string>(type: "text", nullable: true),
                    Categorias = table.Column<int[]>(type: "integer[]", nullable: false),
                    Generos = table.Column<int[]>(type: "integer[]", nullable: false),
                    CastsFilme = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    CaminhoArquivo = table.Column<string>(type: "text", nullable: false),
                    EncodingCaminho = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Videoid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.id);
                    table.ForeignKey(
                        name: "FK_Media_Videos_Videoid",
                        column: x => x.Videoid,
                        principalTable: "Videos",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Media_Videos_id",
                        column: x => x.id,
                        principalTable: "Videos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Media_Videoid",
                table: "Media",
                column: "Videoid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "VideoCastFilme");

            migrationBuilder.DropTable(
                name: "VideoCategoria");

            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
