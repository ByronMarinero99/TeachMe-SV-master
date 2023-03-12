using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;

namespace TeachMeLogicaDeNegocio
{
    public class CredencialPagoBL
    {
        public async Task<int> CrearAsync(CredencialPago pCredencialPago)
        {
            return await CredencialPagoDAL.CrearAsync(pCredencialPago);
        }

        public async Task<int> ModificarAsync(CredencialPago pCredencialPago)
        {
            return await CredencialPagoDAL.ModifycarAsync(pCredencialPago);
        }

        public async Task<int> EliminarAsync(CredencialPago pCredencialPago)
        {
            return await CredencialPagoDAL.EliminarAsync(pCredencialPago);
        }

        public async Task<CredencialPago> ObtenerPorIdAsync(CredencialPago pCredencialPago)
        {
            return await CredencialPagoDAL.ObtenerporIdAsync(pCredencialPago);
        }

        public async Task<List<CredencialPago>> ObtenerTodosAsync()
        {
            return await CredencialPagoDAL.ObtenerTodosAsync();
        }

        public async Task<List<CredencialPago>> BuscarAsync(CredencialPago pCredencialPago)
        {
            return await CredencialPagoDAL.BuscarAsync(pCredencialPago);
        }
    }
}
