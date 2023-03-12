using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeEntidadesDeNegocio
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es Necesario")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Clasificacion es Necesaria")]
        [MaxLength(50, ErrorMessage = "El largo maximo es de 50 caracteres")]
        public string Clasificacion { get; set; }

        public List<Libro> Libros { get; set; } //Propiedad de Navegacion

        public List<Curso> Cursos { get; set; } //Propiedad de Navegacion

        [NotMapped]
        public int top_aux { get; set; } //Propiedad auxiliar sirve para especificar el numero de registro
    }
}
