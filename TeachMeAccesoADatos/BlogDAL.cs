using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..
using Microsoft.EntityFrameworkCore;
using TeachMeEntidadesDeNegocio;

namespace TeachMeAccesoADatos
{
    public class BlogDAL
    {
        // proc para agregar registros

        public static async Task<int> CrearAsync(Blog pBlog)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pBlog);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para modificar
        public static async Task<int> ModifycarAsync(Blog pBlog)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var blog = await bdContexto.Blogs.FirstOrDefaultAsync(c => c.Id == pBlog.Id);
                blog.Nombre = pBlog.Nombre;
                blog.Autor = pBlog.Autor;
                blog.IdCategorias = pBlog.IdCategorias;
                blog.Descripcion = pBlog.Descripcion;
                blog.Contenido = pBlog.Contenido;
                blog.FechaCreacion = pBlog.FechaCreacion;
                blog.ImagenContenido = pBlog.ImagenContenido;
                blog.ImagenDescripcion = pBlog.ImagenDescripcion;

                bdContexto.Update(blog);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para eliminar registros
        public static async Task<int> EliminarAsync(Blog pBlog)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var blog = await bdContexto.Blogs.FirstOrDefaultAsync(c => c.Id == pBlog.Id);
                bdContexto.Blogs.Remove(blog);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para buscar por id
        public static async Task<Blog> ObtenerporIdAsync(Blog pBlog)
        {
            var blog = new Blog();
            using (var bDContexto = new BDContexto())
            {
                blog = await bDContexto.Blogs.FirstOrDefaultAsync(c => c.Id == pBlog.Id);
            }
            return blog;
        }

        // buscar y debuelve una lista 
        public static async Task<List<Blog>> ObtenerTodosAsync()
        {
            var blog = new List<Blog>();
            using (var bdContexto = new BDContexto())
            {
                blog = await bdContexto.Blogs.ToListAsync();
            }
            return blog;
        }

        // busqueda por cualquier campo de texto
        public static IQueryable<Blog> QuerySelect(IQueryable<Blog> pQuery, Blog pBlog)
        {
            if (pBlog.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pBlog.Id);

            if (pBlog.IdCategorias > 0)
                pQuery = pQuery.Where(c => c.IdCategorias == pBlog.IdCategorias);

            if (!string.IsNullOrWhiteSpace(pBlog.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pBlog.Nombre));

            if (!string.IsNullOrWhiteSpace(pBlog.Autor))
                pQuery = pQuery.Where(c => c.Autor.Contains(pBlog.Autor));

            if (!string.IsNullOrWhiteSpace(pBlog.Descripcion))
                pQuery = pQuery.Where(c => c.Descripcion.Contains(pBlog.Descripcion));

            if (!string.IsNullOrWhiteSpace(pBlog.Contenido))
                pQuery = pQuery.Where(c => c.Contenido.Contains(pBlog.Contenido));

            if (!string.IsNullOrWhiteSpace(pBlog.FechaCreacion))
                pQuery = pQuery.Where(c => c.FechaCreacion.Contains(pBlog.FechaCreacion));

            if (!string.IsNullOrWhiteSpace(pBlog.ImagenDescripcion))
                pQuery = pQuery.Where(c => c.ImagenDescripcion.Contains(pBlog.ImagenDescripcion));

            if (!string.IsNullOrWhiteSpace(pBlog.ImagenContenido))
                pQuery = pQuery.Where(c => c.ImagenContenido.Contains(pBlog.ImagenContenido));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pBlog.top_aux > 0)
                pQuery = pQuery.Take(pBlog.top_aux).AsQueryable();

            return pQuery;
        }

        // buscar por un parametro de texto
        public static async Task<List<Blog>> BuscarAsync(Blog pBlog)
        {
            var blog = new List<Blog>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Blogs.AsQueryable();
                select = QuerySelect(select, pBlog);
                blog = await select.ToListAsync();
            }
            return blog;
        }

        public static async Task<List<Blog>> BuscarIncluirCategoriaAsync(Blog pBlog)
        {
            var cursos = new List<Blog>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Blogs.AsQueryable();
                select = QuerySelect(select, pBlog).Include(e => e.Categoria).AsQueryable();
                cursos = await select.ToListAsync();
            }
            return cursos;
        }
    }
}
