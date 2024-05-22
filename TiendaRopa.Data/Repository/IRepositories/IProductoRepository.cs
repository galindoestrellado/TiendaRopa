using System;
using TiendaRopa.Models;

namespace TiendaRopa.Data.Repository.IRepositories
{
    public interface IProductoRepository  : IRepository<Producto>
    {
        void Update(Producto producto);
    }
}
