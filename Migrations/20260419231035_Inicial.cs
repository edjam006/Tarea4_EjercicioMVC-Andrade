using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EjercicioMVCAndrade.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombredelatarea = table.Column<string>(type: "text", nullable: false),
                    FechadeInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    tiempoestimado = table.Column<double>(type: "double precision", nullable: false),
                    EstadoProgreso = table.Column<string>(type: "text", nullable: false),
                    ProyectoId = table.Column<int>(type: "integer", nullable: false),
                    EmpleadoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Empleados",
                columns: new[] { "id", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Perez", "Juan" },
                    { 2, "Gomez", "Maria" },
                    { 3, "Lopez", "Carlos" },
                    { 4, "Martinez", "Ana" },
                    { 5, "Rodriguez", "Pedro" }
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Proyecto A" },
                    { 2, "Proyecto B" },
                    { 3, "Proyecto C" },
                    { 4, "Proyecto D" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "EmpleadoId", "EstadoProgreso", "FechadeInicio", "Nombredelatarea", "ProyectoId", "tiempoestimado" },
                values: new object[,]
                {
                    { 1, 1, "Completado", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Diseño de BD", 1, 40.5 },
                    { 2, 2, "En Progreso", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Desarrollo Backend", 1, 120.0 },
                    { 3, 3, "En Progreso", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Desarrollo Frontend", 1, 100.0 },
                    { 4, 4, "Pendiente", new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Pruebas", 1, 30.0 },
                    { 5, 5, "Completado", new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Análisis de Requisitos", 2, 50.0 },
                    { 6, 1, "Completado", new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Diseño de Interfaz", 2, 60.0 },
                    { 7, 2, "En Progreso", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Implementación", 2, 150.0 },
                    { 8, 3, "Pendiente", new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Despliegue", 2, 20.0 },
                    { 9, 4, "Pendiente", new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Soporte", 2, 40.0 },
                    { 10, 5, "Pendiente", new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Documentación", 3, 30.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_EmpleadoId",
                table: "Tareas",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Proyectos");
        }
    }
}
