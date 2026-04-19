using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EjercicioMVCAndrade.Models
{
    public class Proyecto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public ICollection<Tareas> Tareas { get; set; } = new List<Tareas>();
    }
}
