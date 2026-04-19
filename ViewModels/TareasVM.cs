using System;

namespace EjercicioMVCAndrade.ViewModels
{
    public class TareasVM
    {
        public int Id { get; set; }
        public string Nombredelatarea { get; set; }
        public DateTime FechadeInicio { get; set; }
        public double tiempoestimado { get; set; }
        public string EstadoProgreso { get; set; }
        public string NombreProyecto { get; set; }
        public string NombreEmpleado { get; set; }
        public DateTime? FechaEstimadaFinal { get; set; }
        public int? DiasRetraso { get; set; }
    }
}
