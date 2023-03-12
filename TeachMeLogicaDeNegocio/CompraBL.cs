using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;

namespace TeachMeLogicaDeNegocio
{
    public class CompraBL
    {
        public async Task<int> CrearAsync(Compra pCompra)
        {
            return await CompraDAL.CrearAsync(pCompra);
        }

        public async Task<int> ModificarAsync(Compra pCompra)
        {
            return await CompraDAL.ModificarAsync(pCompra);
        }

        public async Task<int> EliminarAsync(Compra pCompra)
        {
            return await CompraDAL.EliminarAsync(pCompra);
        }

        public async Task<Compra> obtenerPorId(Compra pCompra)
        {
            return await CompraDAL.ObtenerporIdAsync(pCompra);
        }

        public async Task<List<Compra>> ObtenerTodosAsync()
        {
            return await CompraDAL.ObtenerTodosAsync();
        }

        public async Task<List<Compra>> BuscarAsync(Compra pCompra)
        {
            return await CompraDAL.BuscarAsync(pCompra);
        }

        public async Task<List<Compra>> BuscarIncluiEstudianteAsync(Compra pCompra)
        {
            return await CompraDAL.BuscarIncluirEstudiantesAsync(pCompra);
        }
    }
}
