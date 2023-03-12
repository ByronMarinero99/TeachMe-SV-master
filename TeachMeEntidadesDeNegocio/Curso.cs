using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeEntidadesDeNegocio
{
    public  class Curso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Necesario")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "La descripcion es necesaria")]
        [MaxLength(200, ErrorMessage = "El largo maximo es de 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo es de 100 caracteres")]
        public string Precio { get; set; }

        [MaxLength(100, ErrorMessage = "El largo maximo es de 100 caracteres")]
        public string PrecioAnterior { get; set; }

        [Required(ErrorMessage = "El enlace es requerido")]
        [MaxLength(200, ErrorMessage = "El largo maximo es de 200 caracteres")]
        public string Link { get; set; }


        [Required(ErrorMessage = "La duracion es necesaria")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Duracion { get; set; }


        [Required(ErrorMessage = "Los requisitos son necesarios")]
        [MaxLength(300, ErrorMessage = "El largo maximo es de 300 caracteres")]
        public string Requisitos { get; set; }


        [Required(ErrorMessage = "La fecha es necesaria")]
        [MaxLength(20, ErrorMessage = "El largo maximo es de 20 caracteres")]
        public string  FechaCreacion { get; set; }


        [Required(ErrorMessage = "La fecha es necesaria")]
        [MaxLength(20, ErrorMessage = "El largo maximo es de 20 caracteres")]
        public string  FechaActualizacion { get; set; }


        [Required(ErrorMessage = "El link de la imagen es necesario")]
        [MaxLength(500, ErrorMessage = "El largo maximo es de 500 caracteres")]
        public string  Imagen  { get; set; }



        [Required(ErrorMessage = "El autor es necesario")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }


        [Required(ErrorMessage = "El Id de la categoria es necesario")]
        [ForeignKey("Categoria")]
        [Display(Name = "Id Categoria")]
        public int IdCategorias { get; set; }

        public Categoria Categoria { get; set; }



        public List<Compra> compras { get; set; } //Propiedad de Navegacion

        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registro

    }
}
