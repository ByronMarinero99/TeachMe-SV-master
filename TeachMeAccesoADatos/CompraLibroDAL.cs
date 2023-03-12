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
    public class CompraLibroDAL
    {
        // agregar 
        public static async Task<int> CrearAsync(CompraLibro pCompraLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCompraLibro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // Modificar
        public static async Task<int> ModificarAsync(CompraLibro pCompraLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var compraLibro = await bdContexto.ComprasLibros.FirstOrDefaultAsync(c => c.Id == pCompraLibro.Id);
                compraLibro.Monto = pCompraLibro.Monto;
                compraLibro.FechaCompra = pCompraLibro.FechaCompra;
                compraLibro.IdUsuario = pCompraLibro.IdUsuario;
                compraLibro.IdCurso = pCompraLibro.IdCurso;
                compraLibro.IdCredencialesPagos = pCompraLibro.IdCredencialesPagos;


                bdContexto.Update(compraLibro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // eliminar
        public static async Task<int> EliminarAsync(CompraLibro pCompraLibro)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var compraLibro = await bdContexto.ComprasLibros.FirstOrDefaultAsync(c => c.Id == pCompraLibro.Id);
                bdContexto.ComprasLibros.Remove(compraLibro);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // busqueda por Id
        public static async Task<CompraLibro> ObtenerporIdAsync(CompraLibro pCompraLibro)
        {
            var compraLibro = new CompraLibro();
            using (var bDContexto = new BDContexto())
            {
                compraLibro = await bDContexto.ComprasLibros.FirstOrDefaultAsync(c => c.Id == pCompraLibro.Id);
            }
            return compraLibro;
        }

        // buscar y debuelve una lista 
        public static async Task<List<CompraLibro>> ObtenerTodosAsync()
        {
            var compraLibro = new List<CompraLibro>();
            using (var bdContexto = new BDContexto())
            {
                compraLibro = await bdContexto.ComprasLibros.ToListAsync();
            }
            return compraLibro;
        }

        public static IQueryable<CompraLibro> QuerySelect(IQueryable<CompraLibro> pQuery, CompraLibro pCompraLibro)
        {
            if (pCompraLibro.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCompraLibro.Id);

            if (pCompraLibro.IdCurso > 0)
                pQuery = pQuery.Where(c => c.IdCurso == pCompraLibro.IdCurso);

            if (pCompraLibro.IdUsuario > 0)
                pQuery = pQuery.Where(c => c.IdUsuario == pCompraLibro.IdUsuario);

            if (pCompraLibro.IdCredencialesPagos > 0)
                pQuery = pQuery.Where(c => c.IdCredencialesPagos == pCompraLibro.IdCredencialesPagos);

            if (pCompraLibro.Monto > 0)
                pQuery = pQuery.Where(c => c.Monto == pCompraLibro.Monto);

            if (!string.IsNullOrWhiteSpace(pCompraLibro.FechaCompra))
                pQuery = pQuery.Where(c => c.FechaCompra.Contains(pCompraLibro.FechaCompra));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pCompraLibro.top_aux > 0)
                pQuery = pQuery.Take(pCompraLibro.top_aux).AsQueryable();

            return pQuery;
        }

        // busqueda por un valor string
        public static async Task<List<CompraLibro>> BuscarAsync(CompraLibro pCompraLibro)
        {
            var compraLibro = new List<CompraLibro>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.ComprasLibros.AsQueryable();
                select = QuerySelect(select, pCompraLibro);
                compraLibro = await select.ToListAsync();
            }
            return compraLibro;
        }

        public static async Task<List<CompraLibro>> BuscarIncluirEstudiantesAsync(CompraLibro pCompraLibro)
        {
            var comprasLibro = new List<CompraLibro>();
            using (var bdContacto = new BDContexto())
            {
                var select = bdContacto.ComprasLibros.AsQueryable();
                select = QuerySelect(select, pCompraLibro).Include(e => e.Usuario).AsQueryable();
                select = QuerySelect(select, pCompraLibro).Include(e => e.Curso).AsQueryable();
                comprasLibro = await select.ToListAsync();
            }
            return comprasLibro;
        }


    }
}
