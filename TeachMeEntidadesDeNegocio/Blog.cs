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
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Necesario")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El autor es necesario")]
        [MaxLength(100, ErrorMessage = "El largo maximo es de 100 caracteres")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "La descripcion es necesaria")]
        [MaxLength(200, ErrorMessage = "El largo maximo es de 200 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La descripcion es necesaria")]
        [MaxLength(4000, ErrorMessage = "El largo maximo es de 4000 caracteres")]
        public string Contenido { get; set; }


        [Required(ErrorMessage = "La fecha es necesaria")]
        [MaxLength(20, ErrorMessage = "El largo maximo es de 20 caracteres")]
        public string FechaCreacion { get; set; }


        [Required(ErrorMessage = "El link de la imagen es necesario")]
        [MaxLength(500, ErrorMessage = "El largo maximo es de 500 caracteres")]
        public string ImagenDescripcion { get; set; }

        [Required(ErrorMessage = "El link de la imagen es necesario")]
        [MaxLength(500, ErrorMessage = "El largo maximo es de 500 caracteres")]
        public string ImagenContenido { get; set; }


        [Required(ErrorMessage = "El Id de la categoria es necesario")]
        [ForeignKey("Categoria")]
        [Display(Name = "Id Categoria")]
        public int IdCategorias { get; set; }

        public Categoria Categoria { get; set; }


        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registro

    }
}
