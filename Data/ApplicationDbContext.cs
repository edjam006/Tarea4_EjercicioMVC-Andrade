using Microsoft.EntityFrameworkCore;
using EjercicioMVCAndrade.Models;
using System;

namespace EjercicioMVCAndrade.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeo
            modelBuilder.Entity<Empleado>().ToTable("Empleados");
            modelBuilder.Entity<Proyecto>().ToTable("Proyectos");
            modelBuilder.Entity<Tareas>().ToTable("Tareas");

            // Seeding - Empleados
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado { id = 1, Name = "Juan", LastName = "Perez" },
                new Empleado { id = 2, Name = "Maria", LastName = "Gomez" },
                new Empleado { id = 3, Name = "Carlos", LastName = "Lopez" },
                new Empleado { id = 4, Name = "Ana", LastName = "Martinez" },
                new Empleado { id = 5, Name = "Pedro", LastName = "Rodriguez" }
            );

            // Seeding - Proyectos
            modelBuilder.Entity<Proyecto>().HasData(
                new Proyecto { Id = 1, Name = "Proyecto A" },
                new Proyecto { Id = 2, Name = "Proyecto B" },
                new Proyecto { Id = 3, Name = "Proyecto C" },
                new Proyecto { Id = 4, Name = "Proyecto D" }
            );

            // Seeding - Tareas
            modelBuilder.Entity<Tareas>().HasData(
                new Tareas { Id = 1, Nombredelatarea = "Diseño de BD", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 1, 15), DateTimeKind.Utc), tiempoestimado = 40.5, EstadoProgreso = "Completado", ProyectoId = 1, EmpleadoId = 1 },
                new Tareas { Id = 2, Nombredelatarea = "Desarrollo Backend", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 2, 1), DateTimeKind.Utc), tiempoestimado = 120.0, EstadoProgreso = "En Progreso", ProyectoId = 1, EmpleadoId = 2 },
                new Tareas { Id = 3, Nombredelatarea = "Desarrollo Frontend", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 2, 15), DateTimeKind.Utc), tiempoestimado = 100.0, EstadoProgreso = "En Progreso", ProyectoId = 1, EmpleadoId = 3 },
                new Tareas { Id = 4, Nombredelatarea = "Pruebas", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 3, 10), DateTimeKind.Utc), tiempoestimado = 30.0, EstadoProgreso = "Pendiente", ProyectoId = 1, EmpleadoId = 4 },
                new Tareas { Id = 5, Nombredelatarea = "Análisis de Requisitos", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 4, 1), DateTimeKind.Utc), tiempoestimado = 50.0, EstadoProgreso = "Completado", ProyectoId = 2, EmpleadoId = 5 },
                new Tareas { Id = 6, Nombredelatarea = "Diseño de Interfaz", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 4, 15), DateTimeKind.Utc), tiempoestimado = 60.0, EstadoProgreso = "Completado", ProyectoId = 2, EmpleadoId = 1 },
                new Tareas { Id = 7, Nombredelatarea = "Implementación", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 5, 1), DateTimeKind.Utc), tiempoestimado = 150.0, EstadoProgreso = "En Progreso", ProyectoId = 2, EmpleadoId = 2 },
                new Tareas { Id = 8, Nombredelatarea = "Despliegue", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 6, 1), DateTimeKind.Utc), tiempoestimado = 20.0, EstadoProgreso = "Pendiente", ProyectoId = 2, EmpleadoId = 3 },
                new Tareas { Id = 9, Nombredelatarea = "Soporte", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 6, 15), DateTimeKind.Utc), tiempoestimado = 40.0, EstadoProgreso = "Pendiente", ProyectoId = 2, EmpleadoId = 4 },
                new Tareas { Id = 10, Nombredelatarea = "Documentación", FechadeInicio = DateTime.SpecifyKind(new DateTime(2023, 7, 1), DateTimeKind.Utc), tiempoestimado = 30.0, EstadoProgreso = "Pendiente", ProyectoId = 3, EmpleadoId = 5 }
            );
        }
    }
}
