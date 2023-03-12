using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachMeEntidadesDeNegocio;

namespace TeachMeAccesoADatos
{
    public  class CursoDAL
    {
        // proc para agregar registros

        public static async Task<int> CrearAsync(Curso pCurso)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCurso);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para modificar
        public static async Task<int> ModifycarAsync(Curso pCurso)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var curso = await bdContexto.Cursos.FirstOrDefaultAsync(c => c.Id == pCurso.Id);
                curso.Nombre = pCurso.Nombre;
                curso.Autor = pCurso.Autor;
                curso.IdCategorias = pCurso.IdCategorias;
                curso.Descripcion = pCurso.Descripcion;
                curso.Precio = pCurso.Precio;
                curso.PrecioAnterior = pCurso.PrecioAnterior;
                curso.Link = pCurso.Link;
                curso.Duracion = pCurso.Duracion;
                curso.Requisitos = pCurso.Requisitos;
                curso.FechaCreacion = pCurso.FechaCreacion;
                curso.FechaActualizacion = pCurso.FechaActualizacion;
                curso.Imagen = pCurso.Imagen;

                bdContexto.Update(curso);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para eliminar registros
        public static async Task<int> EliminarAsync(Curso pCurso)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var curso = await bdContexto.Cursos.FirstOrDefaultAsync(c => c.Id == pCurso.Id);
                bdContexto.Cursos.Remove(curso);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        // proc para buscar por id
        public static async Task<Curso> ObtenerporIdAsync(Curso pCurso)
        {
            var curso = new Curso();
            using (var bDContexto = new BDContexto())
            {
                curso = await bDContexto.Cursos.FirstOrDefaultAsync(c => c.Id== pCurso.Id);
            }
            return curso;
        }

        // buscar y debuelve una lista 
        public static async Task<List<Curso>> ObtenerTodosAsync()
        {
            var curso = new List<Curso>();
            using (var bdContexto = new BDContexto())
            {
                curso = await bdContexto.Cursos.ToListAsync();
            }
            return curso;
        }

        // busqueda por cualquier campo de texto
        public static IQueryable<Curso> QuerySelect(IQueryable<Curso> pQuery, Curso pCurso)
        {
            if (pCurso.Id > 0)
                pQuery = pQuery.Where(c => c.Id == pCurso.Id);

            if (pCurso.IdCategorias > 0)
                pQuery = pQuery.Where(c => c.IdCategorias == pCurso.IdCategorias);

            if (!string.IsNullOrWhiteSpace(pCurso.Nombre))
                pQuery = pQuery.Where(c => c.Nombre.Contains(pCurso.Nombre));

            if (!string.IsNullOrWhiteSpace(pCurso.Autor))
                pQuery = pQuery.Where(c => c.Autor.Contains(pCurso.Autor));

            if (!string.IsNullOrWhiteSpace(pCurso.Descripcion))
                pQuery = pQuery.Where(c => c.Descripcion.Contains(pCurso.Descripcion));

            if (!string.IsNullOrWhiteSpace(pCurso.Precio))
                pQuery = pQuery.Where(c => c.Precio.Contains(pCurso.Precio));

            if (!string.IsNullOrWhiteSpace(pCurso.PrecioAnterior))
                pQuery = pQuery.Where(c => c.PrecioAnterior.Contains(pCurso.PrecioAnterior));

            if (!string.IsNullOrWhiteSpace(pCurso.Link))
                pQuery = pQuery.Where(c => c.Link.Contains(pCurso.Link));

            if (!string.IsNullOrWhiteSpace(pCurso.Duracion))
                pQuery = pQuery.Where(c => c.Duracion.Contains(pCurso.Duracion));

            if (!string.IsNullOrWhiteSpace(pCurso.Requisitos))
                pQuery = pQuery.Where(c => c.Requisitos.Contains(pCurso.Requisitos));

            if (!string.IsNullOrWhiteSpace(pCurso.FechaCreacion))
                pQuery = pQuery.Where(c => c.FechaCreacion.Contains(pCurso.FechaCreacion));

            if (!string.IsNullOrWhiteSpace(pCurso.FechaActualizacion))
                pQuery = pQuery.Where(c => c.Duracion.Contains(pCurso.Duracion));

            if (!string.IsNullOrWhiteSpace(pCurso.Imagen))
                pQuery = pQuery.Where(c => c.Imagen.Contains(pCurso.Imagen));

            pQuery = pQuery.OrderByDescending(c => c.Id).AsQueryable();

            if (pCurso.top_aux > 0)
                pQuery = pQuery.Take(pCurso.top_aux).AsQueryable();

            return pQuery;
        }


        // buscar por un parametro de texto
        public static async Task<List<Curso>> BuscarAsync(Curso pCurso)
        {
            var curso = new List<Curso>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cursos.AsQueryable();
                select = QuerySelect(select, pCurso);
                curso = await select.ToListAsync();
            }
            return curso;
        }

        public static async Task<List<Curso>> BuscarIncluirCategoriaAsync(Curso pCurso)
        {
            var cursos = new List<Curso>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cursos.AsQueryable();
                select = QuerySelect(select, pCurso).Include(e => e.Categoria).AsQueryable();
                cursos = await select.ToListAsync();
            }
            return cursos;
        }
    }
}
