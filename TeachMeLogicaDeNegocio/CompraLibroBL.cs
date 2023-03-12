using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;

namespace TeachMeLogicaDeNegocio
{
    public class CompraLibroBL
    {
        public async Task<int> CrearAsync(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.CrearAsync(pCompraLibro);
        }

        public async Task<int> ModificarAsync(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.ModificarAsync(pCompraLibro);
        }

        public async Task<int> EliminarAsync(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.EliminarAsync(pCompraLibro);
        }

        public async Task<CompraLibro> obtenerPorId(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.ObtenerporIdAsync(pCompraLibro);
        }

        public async Task<List<CompraLibro>> ObtenerTodosAsync()
        {
            return await CompraLibroDAL.ObtenerTodosAsync();
        }

        public async Task<List<CompraLibro>> BuscarAsync(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.BuscarAsync(pCompraLibro);
        }

        public async Task<List<CompraLibro>> BuscarIncluiEstudianteAsync(CompraLibro pCompraLibro)
        {
            return await CompraLibroDAL.BuscarIncluirEstudiantesAsync(pCompraLibro);
        }
    }
}
