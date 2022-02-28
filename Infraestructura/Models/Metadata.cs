using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Models
{
    internal partial class CasaMetadata
    {
        [Display(Name = "Casa")]
        public int IdCasa { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }
        [Display(Name = "Tipo Casa")]
        public int IDTipoCasa { get; set; }
        public virtual TipoCasa TipoCasa { get; set; }
    }

    internal partial class TipoCasaMetadata
    {
        [Display(Name = "Identificacion")]
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Casa> Casa { get; set; }
    }

    internal partial class UsuarioMetadata
    {
        [Required(ErrorMessage = "{0} es un dato requerido")]
        public int Identificacion { get; set; }

        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }

        public string Correo { get; set; }

        public int Telefono { get; set; }

        [Display(Name = "Rol")]
        public int IdRol { get; set; }

        public int Estado { get; set; }

        [Required(ErrorMessage = "{0} es un dato requerido")]
        public string Contraseña { get; set; }
        public virtual Rol Rol { get; set; }
    }

    internal partial class ServicioMetadata
    {
        [Display(Name = "Identificacion")]
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public int Precio { get; set; }

    }
}
