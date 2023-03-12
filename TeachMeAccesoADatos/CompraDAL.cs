using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//..
using Microsoft.EntityFrameworkCore;
using TeachMeEntidadesDeNegocio;

namespace TeachMeAccesoADatos
{
    public class CompraDAL
    {
        // agregar 
        public static async Task<int> CrearAsync(Compra pCompra)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCompra);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // Modificar
        public static async Task<int> ModificarAsync(Compra pCompra)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var compra = await bdContexto.Compras.FirstOrDefaultAsync(c => c.Id == pCompra.Id);
                compra.Monto = pCompra.Monto;
                compra.FechaCompra = pCompra.FechaCompra;
                compra.IdUsuario = pCompra.IdUsuario;
                compra.IdCurso = pCompra.IdCurso;
                compra.IdCredencialesPagos = pCompra.IdCredencialesPagos;


                bdContexto.Update(compra);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // eliminar
        public static async Task<int> EliminarAsync(Compra pCompras)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var compra = await bdContexto.Compras.FirstOrDefaultAsync(c => c.Id == pCompras.Id);
                bdContexto.Compras.Remove(compra);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // busqueda por Id
        public static async Task<Compra> ObtenerporIdAsync(Compra pCompras)
        {
            var compra = new Compra();
            using (var bDContexto = new BDContexto())
            {
                compra = await bDContexto.Compras.FirstOrDefaultAsync(c => c.Id== pCompras.Id);
            }
            return compra;
        }

        // buscar y debuelve una lista 
        public static async Task<List<Compra>> ObtenerTodosAsync()
        {
            var compra = new List<Compra>();
            using (var bdContexto = new BDContexto())
            {
                compra = await bdContexto.Compras.ToListAsync();
            }
            return compra;
        }

        public static IQueryable<Compra> QuerySelect(IQueryable<Compra> pQuery, Compra pCompra)
        {
            if (pCompra.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCompra.Id);

            if (pCompra.IdCurso > 0)
                pQuery = pQuery.Where(c => c.IdCurso == pCompra.IdCurso);

            if (pCompra.IdUsuario > 0)
                pQuery = pQuery.Where(c => c.IdUsuario == pCompra.IdUsuario);

            if (pCompra.IdCredencialesPagos > 0)
                pQuery = pQuery.Where(c => c.IdCredencialesPagos == pCompra.IdCredencialesPagos);

            if (pCompra.Monto > 0)
                pQuery = pQuery.Where(c => c.Monto == pCompra.Monto);

            if (!string.IsNullOrWhiteSpace(pCompra.FechaCompra))
                pQuery = pQuery.Where(c => c.FechaCompra.Contains(pCompra.FechaCompra));


            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pCompra.top_aux > 0)
                pQuery = pQuery.Take(pCompra.top_aux).AsQueryable();

            return pQuery;
        }

        // busqueda por un valor string
        public static async Task<List<Compra>> BuscarAsync(Compra pCompra)
        {
            var compra = new List<Compra>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Compras.AsQueryable();
                select = QuerySelect(select, pCompra);
                compra = await select.ToListAsync();
            }
            return compra;
        }

        public static async Task<List<Compra>> BuscarIncluirEstudiantesAsync(Compra pCompra)
        {
            var compras = new List<Compra>();
            using (var bdContacto = new BDContexto())
            {
                var select = bdContacto.Compras.AsQueryable();
                select = QuerySelect(select, pCompra).Include(e => e.Usuario).AsQueryable();
                select = QuerySelect(select, pCompra).Include(e => e.Curso).AsQueryable();
                select = QuerySelect(select, pCompra).Include(e => e.CredencialPago).AsQueryable();
                compras = await select.ToListAsync();
            }
            return compras;
        }
    }
}
