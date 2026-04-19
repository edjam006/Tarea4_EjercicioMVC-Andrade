using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EjercicioMVCAndrade.Models
{
    public class Empleado
    {
        [Key]
        public int id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string LastName { get; set; }

        public ICollection<Tareas> Tareas { get; set; } = new List<Tareas>();
    }
}
