using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeEntidadesDeNegocio
{
    public  class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [MaxLength(100, ErrorMessage ="has sobrepasado la cantidad maxima de caracteres")]
        public string Nombre { get; set; }


        [MaxLength(200, ErrorMessage = "has sobrepasado la cantidad maxima de caracteres")]
        public string Descripcion { get; set; }


        [MaxLength(100, ErrorMessage = "has sobrepasado la cantidad maxima de caracteres")]
        [Required( ErrorMessage ="el precio es requerido")]
        public string Precio { get; set; }

        [MaxLength(100, ErrorMessage = "El largo maximo es de 100 caracteres")]
        public string PrecioAnterior { get; set; }

        [Required(ErrorMessage = "El enlace es requerido")]
        [MaxLength(200, ErrorMessage = "El largo maximo es de 200 caracteres")]
        public string Link { get; set; }

        [MaxLength(50, ErrorMessage = "has sobrepasado la cantidad maxima de caracteres")]
        [Required(ErrorMessage = "Es requerido")]
        public string Editorial { get; set; }

        [Required(ErrorMessage = "Es requerido")]
        public int Edicion { get; set; }

        [MaxLength(10, ErrorMessage = "has sobrepasado la cantidad maxima de caracteres")]
        [Required(ErrorMessage = "Es requerido")]
        public string FechaPublicacion { get; set; }


        [Required(ErrorMessage = "La cantidad es requerida")]
        public int CantidadPag { get; set; }

        [Required(ErrorMessage = "La imagen es requerida")]
        public string Imagen { get; set; }


        [Required(ErrorMessage = "El Id del autor es necesario")]
        [Display(Name = "Id de autor")]
        public string Autor { get; set; }


        [Required(ErrorMessage = "El Id categoria es necesario")]
        [ForeignKey("Categoria")]
        [Display(Name = "Id Categoria")]
        public int IdCategorias { get; set; }
        public Categoria Categoria { get; set; }


        [NotMapped]

        public int top_aux { get; set; }

    }
}
