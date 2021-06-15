using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CondominioAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Identificacion = table.Column<long>(nullable: false),
                    Telefono = table.Column<long>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Celular = table.Column<long>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bloque = table.Column<string>(nullable: true),
                    NumeroDepartamento = table.Column<string>(nullable: true),
                    NumeroDormitorios = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    FechaActualizacion = table.Column<DateTime>(nullable: false),
                    PropietarioId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamentos_Residentes_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Residentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alquileres",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    DepartamentoId = table.Column<long>(nullable: true),
                    ArrendatarioId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alquileres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alquileres_Residentes_ArrendatarioId",
                        column: x => x.ArrendatarioId,
                        principalTable: "Residentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alquileres_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_ArrendatarioId",
                table: "Alquileres",
                column: "ArrendatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alquileres_DepartamentoId",
                table: "Alquileres",
                column: "DepartamentoId",
                unique: true,
                filter: "[DepartamentoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_PropietarioId",
                table: "Departamentos",
                column: "PropietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alquileres");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Residentes");
        }
    }
}
