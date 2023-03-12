using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TeachMeEntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;

namespace TeachMeAccesoADatos
{
    public class CredencialPagoDAL
    {
        // proc para agregar registros

        public static async Task<int> CrearAsync(CredencialPago pCredencialPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCredencialPago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para modificar
        public static async Task<int> ModifycarAsync(CredencialPago pCredencialPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var credencialPago = await bdContexto.CredencialesPagos.FirstOrDefaultAsync(c => c.Id == pCredencialPago.Id);
                credencialPago.NumeroTarjeta = pCredencialPago.NumeroTarjeta;
                credencialPago.Marca = pCredencialPago.Marca;
                credencialPago.Pais = pCredencialPago.Pais;
                credencialPago.CVC = pCredencialPago.CVC;
                credencialPago.FechaCreacion = pCredencialPago.FechaCreacion;
                credencialPago.FechaVencimiento = pCredencialPago.FechaVencimiento;

                bdContexto.Update(credencialPago);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para eliminar registros
        public static async Task<int> EliminarAsync(CredencialPago pCredencialPago)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var credencialPagos = await bdContexto.CredencialesPagos.FirstOrDefaultAsync(c => c.Id == pCredencialPago.Id);
                bdContexto.CredencialesPagos.Remove(credencialPagos);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para buscar por id
        public static async Task<CredencialPago> ObtenerporIdAsync(CredencialPago pCredencialPago)
        {
            var credencialPago = new CredencialPago();
            using (var bDContexto = new BDContexto())
            {
                credencialPago = await bDContexto.CredencialesPagos.FirstOrDefaultAsync(c => c.Id == pCredencialPago.Id);
            }
            return credencialPago;
        }

        // buscar y debuelve una lista 
        public static async Task<List<CredencialPago>> ObtenerTodosAsync()
        {
            var credencialPago = new List<CredencialPago>();
            using (var bdContexto = new BDContexto())
            {
                credencialPago = await bdContexto.CredencialesPagos.ToListAsync();
            }
            return credencialPago;
        }

        // busqueda por cualquier campo de texto
        public static IQueryable<CredencialPago> QuerySelect(IQueryable<CredencialPago> pQuery, CredencialPago pCredencialPago)
        {
            if (pCredencialPago.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCredencialPago.Id);

            if (!string.IsNullOrWhiteSpace(pCredencialPago.NumeroTarjeta))
                pQuery = pQuery.Where(c => c.NumeroTarjeta.Contains(pCredencialPago.NumeroTarjeta));

            if (!string.IsNullOrWhiteSpace(pCredencialPago.Marca))
                pQuery = pQuery.Where(c => c.Marca.Contains(pCredencialPago.Marca));

            if (!string.IsNullOrWhiteSpace(pCredencialPago.Pais))
                pQuery = pQuery.Where(c => c.Pais.Contains(pCredencialPago.Pais));

            if (pCredencialPago.CVC > 0)
                pQuery = pQuery.Where(c => c.CVC == pCredencialPago.CVC);

            if (!string.IsNullOrWhiteSpace(pCredencialPago.FechaCreacion))
                pQuery = pQuery.Where(c => c.FechaCreacion.Contains(pCredencialPago.FechaCreacion));

            if (!string.IsNullOrWhiteSpace(pCredencialPago.FechaVencimiento))
                pQuery = pQuery.Where(c => c.FechaVencimiento.Contains(pCredencialPago.FechaVencimiento));


            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pCredencialPago.top_aux > 0)
                pQuery = pQuery.Take(pCredencialPago.top_aux).AsQueryable();

            return pQuery;
        }

        // buscar por un parametro de texto
        public static async Task<List<CredencialPago>> BuscarAsync(CredencialPago pCredencialPagos)
        {
            var CredencialPagos = new List<CredencialPago>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.CredencialesPagos.AsQueryable();
                select = QuerySelect(select, pCredencialPagos);
                CredencialPagos = await select.ToListAsync();
            }
            return CredencialPagos;
        }
    }
}
