using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeEntidadesDeNegocio
{
   public class Compra
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "El monto es Necesario")]
        public int Monto { get; set; }

        [Required(ErrorMessage = "El la fecha es necesaria")]
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

        public Curso Curso  { get; set; }

        [Required(ErrorMessage = "El Id del pago es Necesario")]
        [ForeignKey("CredencialPago")]
        [Display(Name = "Id de credencial de pago")]
        public int IdCredencialesPagos { get; set; }

        public CredencialPago CredencialPago { get; set; }

        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registro
    }
}
