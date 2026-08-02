using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Catalogo.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemoverIdGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idGuid",
                table: "Categorias");

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    categoriasId = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenerosCategorias",
                columns: table => new
                {
                    ID_CATEGORIA = table.Column<int>(type: "integer", nullable: false),
                    ID_GENERO = table.Column<int>(type: "integer", nullable: false),
                    Categoriaid = table.Column<int>(type: "integer", nullable: false),
                    Generoid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosCategorias", x => new { x.ID_CATEGORIA, x.ID_GENERO });
                    table.ForeignKey(
                        name: "FK_GenerosCategorias_Categorias_Categoriaid",
                        column: x => x.Categoriaid,
                        principalTable: "Categorias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerosCategorias_Generos_Generoid",
                        column: x => x.Generoid,
                        principalTable: "Generos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenerosCategorias_Categoriaid",
                table: "GenerosCategorias",
                column: "Categoriaid");

            migrationBuilder.CreateIndex(
                name: "IX_GenerosCategorias_Generoid",
                table: "GenerosCategorias",
                column: "Generoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerosCategorias");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.AddColumn<Guid>(
                name: "idGuid",
                table: "Categorias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
