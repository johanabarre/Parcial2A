using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2A.Entities
{
    public class Dosis
    {
        [Key]
        public int DosisId { get; set; }
        [MaxLength(30)]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Presentacion { get; set; }//Ya sea inyectada o Bebible
        [Required]
        public string CantidadAdministrada { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }

       


    }
}
