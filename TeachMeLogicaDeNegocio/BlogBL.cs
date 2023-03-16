using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//...
using TeachMeAccesoADatos;
using TeachMeEntidadesDeNegocio;

namespace TeachMeLogicaDeNegocio
{
    public class BlogBL
    {
        public async Task<int> CrearAsync(Blog pBlog)
        {
            return await BlogDAL.CrearAsync(pBlog);
        }

        public async Task<int> ModificarAsync(Blog pBlog)
        {
            return await BlogDAL.ModifycarAsync(pBlog);
        }

        public async Task<int> EliminarAsync(Blog pBlog)
        {
            return await BlogDAL.EliminarAsync(pBlog);
        }

        public async Task<Blog> ObtenerPorIdAsync(Blog pBlog)
        {
            return await BlogDAL.ObtenerporIdAsync(pBlog);
        }

        public async Task<List<Blog>> ObtenerTodosAsync()
        {
            return await BlogDAL.ObtenerTodosAsync();
        }

        public async Task<List<Blog>> BuscarAsync(Blog pBlog)
        {
            return await BlogDAL.BuscarAsync(pBlog);
        }

        public async Task<List<Blog>> BuscarIncluirCategoriaAsync(Blog pBlog)
        {
            return await BlogDAL.BuscarIncluirCategoriaAsync(pBlog);
        }
    }
}
