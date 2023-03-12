using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeachMeEntidadesDeNegocio
{
    public class CompraLibro
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El monto es Necesario")]
        public int Monto { get; set; }


        [MaxLength(10, ErrorMessage = "El largo maximo es de 10 caracteres")]
        [Required(ErrorMessage = "La fecha es Necesario")]
        public string FechaCompra { get; set; }


        [Required(ErrorMessage = "El Id del estudiante es Necesario")]
        [ForeignKey("Usuario")]
        [Display(Name = "Id del usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "El Id del curso es Necesario")]
        [ForeignKey("Curso")]
        [Display(Name = "Id del curso")]
        public int IdCurso { get; set; }
        public Curso Curso { get; set; }

        [Required(ErrorMessage = "El Id de la credencial es Necesario")]
        [ForeignKey("CredencialPago")]
        [Display(Name = "Id de la credencial")]
        public int IdCredencialesPagos { get; set; }

        public CredencialPago CredencialPago { get; set; }

        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registro
    }
}
