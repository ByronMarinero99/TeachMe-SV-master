using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//namespace
using TeachMeEntidadesDeNegocio;

using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace TeachMeAccesoADatos
{
    public class LibroDAL
    {
        public static async Task<int> CrearAsync (Libro pLibro)
         {
            int resultado = 0;
           using  (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pLibro);
                resultado = await bdContexto.SaveChangesAsync();

            }
            return resultado;


         }

        public static async Task<int> ModificarAsync(Libro pLibro)
        {
            int resultado = 0;
            using (var bdContexto = new BDContexto())
            {
                var libro = await bdContexto.Libros.FirstOrDefaultAsync(c => c.Id == pLibro.Id);
                libro.Nombre = pLibro.Nombre;
                libro.Autor = pLibro.Autor;
                libro.IdCategorias = pLibro.IdCategorias;
                libro.Descripcion = pLibro.Descripcion;
                libro.Precio = pLibro.Precio;
                libro.PrecioAnterior = pLibro.PrecioAnterior;
                libro.Link = pLibro.Link;
                libro.Editorial = pLibro.Editorial;
                libro.Edicion = pLibro.Edicion;
                libro.FechaPublicacion = pLibro.FechaPublicacion;
                libro.CantidadPag = pLibro.CantidadPag;
                libro.Imagen = pLibro.Imagen;

                bdContexto.Update(libro);
                resultado = await bdContexto.SaveChangesAsync();
            }
            return resultado;
        }
        public static async Task <int> EliminarAsync (Libro pLibro)
        {
            int resultado = 0;
            using (var bdContexto = new BDContexto())
            {

                var libro = await bdContexto.Libros.FirstOrDefaultAsync(e => e.Id == pLibro.Id);
                bdContexto.Libros.Remove(libro);
                resultado = await bdContexto.SaveChangesAsync();
            }
            return resultado;

        }
        public static async Task <Libro> ObtenerPorIdAsync(Libro pLibro)
        {
            var libro = new Libro();
            using (var bdContexto = new BDContexto())
            {
                libro = await bdContexto.Libros.FirstOrDefaultAsync(
                    e => e.Id == pLibro.Id);

            }
            return libro;

        }
        public static async Task<List<Libro>> ObtenerTodosAsync()
        {
            var libro = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                libro = await bdContexto.Libros.ToListAsync();
            }
            return libro;
        }
        internal static IQueryable<Libro> QuerySelect(IQueryable<Libro> pQuery, Libro pLibro)
        {
            if (pLibro.Id > 0)
                pQuery = pQuery.Where(e => e.Id == pLibro.Id);

            if (pLibro.IdCategorias > 0)
                pQuery = pQuery.Where(e => e.IdCategorias == pLibro.IdCategorias);

            if (!string.IsNullOrWhiteSpace(pLibro.Nombre))
                pQuery = pQuery.Where(e => e.Nombre == pLibro.Nombre);
            if (!string.IsNullOrWhiteSpace(pLibro.Autor))
                pQuery = pQuery.Where(e => e.Autor == pLibro.Autor);

            if (!string.IsNullOrEmpty(pLibro.Descripcion))
                pQuery = pQuery.Where(e => e.Descripcion == pLibro.Descripcion);

            if (!string.IsNullOrEmpty(pLibro.Precio))
                pQuery = pQuery.Where(e => e.Precio == pLibro.Precio);

            if (!string.IsNullOrEmpty(pLibro.PrecioAnterior))
                pQuery = pQuery.Where(e => e.PrecioAnterior == pLibro.PrecioAnterior);

            if (!string.IsNullOrEmpty(pLibro.Link))
                pQuery = pQuery.Where(e => e.Link == pLibro.Link);

            if (!string.IsNullOrEmpty(pLibro.Editorial))
                pQuery = pQuery.Where(e => e.Editorial == pLibro.Editorial);

            if (pLibro.Edicion > 0)
                pQuery = pQuery.Where(e => e.Edicion == pLibro.Edicion);

            if (!string.IsNullOrEmpty(pLibro.FechaPublicacion))
                pQuery = pQuery.Where(e => e.FechaPublicacion == pLibro.FechaPublicacion);

            if (pLibro.CantidadPag > 0)
                pQuery = pQuery.Where(e => e.CantidadPag == pLibro.CantidadPag);


            pQuery = pQuery.OrderByDescending(e => e.Id).AsQueryable();
            if (pLibro.top_aux > 0)
                pQuery = pQuery.Take(pLibro.top_aux).AsQueryable();
            return pQuery;

        }
        public static async Task<List<Libro>> BuscarAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libros.AsQueryable();
                select = QuerySelect(select, pLibro);
                libros = await select.ToListAsync();

            }
            return libros;

        }
        public static async Task<List<Libro>> BuscarIncluirLibroAsync(Libro pLibro)
        {
            var libros = new List<Libro>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Libros.AsQueryable();
                select = QuerySelect(select, pLibro).Include(e => e.Categoria).AsQueryable();
                libros = await select.ToListAsync();
            }
            return libros;
        }
    }
}
