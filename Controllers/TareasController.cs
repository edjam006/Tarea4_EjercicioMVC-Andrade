using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EjercicioMVCAndrade.Data;
using EjercicioMVCAndrade.ViewModels;
using EjercicioMVCAndrade.Models;

namespace EjercicioMVCAndrade.Controllers
{
    public class TareasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TareasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tareas
        public async Task<IActionResult> Index()
        {
            var tareas = await _context.Tareas
                .Include(t => t.Empleado)
                .Include(t => t.Proyecto)
                .Select(t => new TareasVM
                {
                    Id = t.Id,
                    Nombredelatarea = t.Nombredelatarea,
                    FechadeInicio = t.FechadeInicio,
                    tiempoestimado = t.tiempoestimado,
                    EstadoProgreso = t.EstadoProgreso,
                    NombreProyecto = t.Proyecto.Name,
                    NombreEmpleado = t.Empleado.Name + " " + t.Empleado.LastName
                })
                .ToListAsync();

            return View(tareas);
        }

        // POST: Tareas/FiltrarPorFechas
        [HttpPost]
        public async Task<IActionResult> FiltrarPorFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            var DateTimeMin = DateTime.SpecifyKind(fechaInicio, DateTimeKind.Utc);
            var DateTimeMax = DateTime.SpecifyKind(fechaFin, DateTimeKind.Utc);

            var tareasContext = await _context.Tareas
                .Include(t => t.Empleado)
                .Include(t => t.Proyecto)
                .Where(t => t.EstadoProgreso == "En Progreso" && t.FechadeInicio >= DateTimeMin && t.FechadeInicio <= DateTimeMax)
                .ToListAsync();

            var tareasVM = tareasContext.Select(t => {
                var vm = new TareasVM
                {
                    Id = t.Id,
                    Nombredelatarea = t.Nombredelatarea,
                    FechadeInicio = t.FechadeInicio,
                    tiempoestimado = t.tiempoestimado,
                    EstadoProgreso = t.EstadoProgreso,
                    NombreProyecto = t.Proyecto.Name,
                    NombreEmpleado = t.Empleado.Name + " " + t.Empleado.LastName
                };

                // Asumimos que tiempoestimado es en horas y un dia laboral tiene 8 horas.
                // Sumamos días correspondientes a tiempoestimado.
                vm.FechaEstimadaFinal = CalcularFechaEstimada(t.FechadeInicio, t.tiempoestimado);
                vm.DiasRetraso = CalcularDiasRetraso(vm.FechaEstimadaFinal.Value);

                return vm;
            }).ToList();

            return View("Index", tareasVM);
        }

        private DateTime CalcularFechaEstimada(DateTime inicio, double horasEstimadas)
        {
            int diasAAnadir = (int)Math.Ceiling(horasEstimadas / 8.0);
            DateTime fechaFinal = inicio;
            
            while (diasAAnadir > 0)
            {
                fechaFinal = fechaFinal.AddDays(1);
                if (fechaFinal.DayOfWeek != DayOfWeek.Saturday && fechaFinal.DayOfWeek != DayOfWeek.Sunday)
                {
                    diasAAnadir--;
                }
            }
            return fechaFinal;
        }

        private int CalcularDiasRetraso(DateTime fechaEstimada)
        {
            int retraso = 0;
            DateTime hoy = DateTime.UtcNow.Date;
            DateTime calculo = fechaEstimada.Date;

            if (calculo >= hoy) return 0;

            while (calculo < hoy)
            {
                calculo = calculo.AddDays(1);
                if (calculo.DayOfWeek != DayOfWeek.Saturday && calculo.DayOfWeek != DayOfWeek.Sunday)
                {
                    retraso++;
                }
            }
            return retraso;
        }
    }
}
