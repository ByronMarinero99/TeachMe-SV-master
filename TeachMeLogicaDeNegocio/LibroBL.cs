using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachMeEntidadesDeNegocio;
using TeachMeAccesoADatos;

namespace TeachMeLogicaDeNegocio
{
    public class LibroBL
    {
            public async Task<int> CrearAsync(Libro pLibro)
            {
                return await LibroDAL.CrearAsync(pLibro);

            }

            public async Task<int> ModificarAsync(Libro pLibro)
            {
                return await LibroDAL.ModificarAsync(pLibro);

            }
            public async Task<int> EliminarAsync(Libro pLibro)
            {
                return await LibroDAL.EliminarAsync(pLibro);

            }
            public async Task<Libro> ObtenerPorIdAsync(Libro pLibro)
            {
                return await LibroDAL.ObtenerPorIdAsync(pLibro);
            }
            public async Task<List<Libro>> ObtenerTodosAsync()
            {
                return await LibroDAL.ObtenerTodosAsync();
            }
            public async Task<List<Libro>> BuscarIncluirLibroAsync(Libro pLibro)
            {
                return await LibroDAL.BuscarIncluirLibroAsync(pLibro);
            }
    }
}
