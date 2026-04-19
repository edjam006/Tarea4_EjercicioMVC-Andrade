using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EjercicioMVCAndrade.Models
{
    public class Tareas
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Nombredelatarea { get; set; }
        
        public DateTime FechadeInicio { get; set; }
        
        public double tiempoestimado { get; set; }
        
        public string EstadoProgreso { get; set; }

        public int ProyectoId { get; set; }
        [ForeignKey("ProyectoId")]
        public Proyecto Proyecto { get; set; }

        public int EmpleadoId { get; set; }
        [ForeignKey("EmpleadoId")]
        public Empleado Empleado { get; set; }
    }
}
