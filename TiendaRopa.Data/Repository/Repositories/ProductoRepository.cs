using TiendaRopa.Data.Data;
using TiendaRopa.Data.Repository.IRepositories;
using TiendaRopa.Models;

namespace TiendaRopa.Data.Repository.Repositories
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Producto producto)
        {
            var productoBD = _db.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if(productoBD != null)
            {
                productoBD.Talla = producto.Talla;
                productoBD.Color = producto.Color;
                productoBD.Precio = producto.Precio;
                productoBD.Descripcion = producto.Descripcion;
                _db.SaveChanges();
            }
        }
    }
}
