using Microsoft.EntityFrameworkCore;
using TeachMeEntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachMeAccesoADatos
{
        public class BDContexto : DbContext
        {
            public DbSet<Rol> Roles { get; set; }
             
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Curso> Cursos { get; set; }
            public DbSet<Libro> Libros { get; set; }
            public DbSet<Compra> Compras { get; set; }
            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<CompraLibro> ComprasLibros { get; set; }
            public DbSet<CredencialPago> CredencialesPagos { get; set; }
            public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            {
                // BD local de byron
                options.UseSqlServer(@"Data Source=;Initial Catalog=TeachMe;Integrated Security=True");

                // BD local de fernando
                //options.UseSqlServer(@"Data Source=DESKTOP-5D189V7;Initial Catalog=TeachMe;Integrated Security=True");

                // BD local de daniel
                //options.UseSqlServer(@"Data Source=.;Initial Catalog=TeachMe;Integrated Security=True");

                // BD local de Israel
                //options.UseSqlServer(@"Data Source=.;Initial Catalog=TeachMe;Integrated Security=True");
            }
        }
}
