using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeEntidadesDeNegocio
{
    public class CredencialPago
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(18, ErrorMessage = "El largo maximo es de 18 caracteres")]
        [Required(ErrorMessage = "El numero de la tarjeta es requerida")]
        public string NumeroTarjeta { get; set; }

        [MaxLength(100, ErrorMessage = "El largo maximo es de 100 caracteres")]
        [Required(ErrorMessage = "El numero de la tarjeta es requerida")]
        public string Marca { get; set; }

        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        [Required(ErrorMessage = "El pais es requerido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El numero CVC")]
        public int CVC { get; set; }

        [MaxLength(10, ErrorMessage = "El largo maximo es de 10 caracteres")]
        [Required(ErrorMessage = "El pais es requerido")]
        public string FechaCreacion { get; set; }

        [MaxLength(10, ErrorMessage = "El largo maximo es de 10 caracteres")]
        [Required(ErrorMessage = "El pais es requerido")]
        public string FechaVencimiento { get; set; }

        public List<CompraLibro> CompraLibros { get; set; } //Propiedad de Navegacion

        public List<Compra> Compra { get; set; } //Propiedad de Navegacion

        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registr
    }
}
