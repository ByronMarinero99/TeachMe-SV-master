using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//.......
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;

namespace TeachMeLogicaDeNegocio
{
    public class CursoBL
    {
        public async Task<int> CrearAsync(Curso pContacto)
        {
            return await CursoDAL.CrearAsync(pContacto);
        }

        public async Task<int> ModificarAsync(Curso pContacto)
        {
            return await CursoDAL.ModifycarAsync(pContacto);
        }

        public async Task<int> EliminarAsync(Curso pContacto)
        {
            return await CursoDAL.EliminarAsync(pContacto);
        }

        public async Task<Curso> ObtenerPorIdAsync(Curso pContacto)
        {
            return await CursoDAL.ObtenerporIdAsync(pContacto);
        }

        public async Task<List<Curso>> ObtenerTodosAsync()
        {
            return await CursoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Curso>> BuscarAsync(Curso pContacto)
        {
            return await CursoDAL.BuscarAsync(pContacto);
        }

        public async Task<List<Curso>> BuscarIncluirCategoriaAsync(Curso pContacto)
        {
            return await CursoDAL.BuscarIncluirCategoriaAsync(pContacto);
        }

        
    }
}
