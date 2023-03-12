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
    public class CategoriaDAL
    {
        public static async Task<int> CrearAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCategoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // Modificar
        public static async Task<int> ModificarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
                categoria.Nombre = pCategoria.Nombre;
                categoria.Clasificacion = pCategoria.Clasificacion;

                bdContexto.Update(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // eliminar
        public static async Task<int> EliminarAsync(Categoria pCategoria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var categoria = await bdContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
                bdContexto.Categorias.Remove(categoria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // busqueda por Id
        public static async Task<Categoria> ObtenerporIdAsync(Categoria pCategoria)
        {
            var categoria = new Categoria();
            using (var bDContexto = new BDContexto())
            {
                categoria = await bDContexto.Categorias.FirstOrDefaultAsync(c => c.Id == pCategoria.Id);
            }
            return categoria;
        }

        // buscar y debuelve una lista 
        public static async Task<List<Categoria>> ObtenerTodosAsync()
        {
            var categoria = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                categoria = await bdContexto.Categorias.ToListAsync();
            }
            return categoria;
        }

        public static IQueryable<Categoria> QuerySelect(IQueryable<Categoria> pQuery, Categoria pCategoria)
        {
            if (pCategoria.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCategoria.Id);

            if (!string.IsNullOrWhiteSpace(pCategoria.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pCategoria.Nombre));

            if (!string.IsNullOrWhiteSpace(pCategoria.Clasificacion))
                pQuery = pQuery.Where(c => c.Clasificacion.Contains(pCategoria.Clasificacion));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pCategoria.top_aux > 0)
                pQuery = pQuery.Take(pCategoria.top_aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Categoria>> BuscarAsync(Categoria pCategoria)
        {
            var categoria = new List<Categoria>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Categorias.AsQueryable();
                select = QuerySelect(select, pCategoria);
                categoria = await select.ToListAsync();
            }
            return categoria;
        }
    }
}
