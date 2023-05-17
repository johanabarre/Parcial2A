using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2A.Entities
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Edad { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int DosisId { get; set; }


        public virtual ICollection<Dosis> Doses { get; set; }


    }
}
