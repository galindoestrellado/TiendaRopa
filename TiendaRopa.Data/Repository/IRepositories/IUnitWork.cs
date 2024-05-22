
namespace TiendaRopa.Data.Repository.IRepositories
{
    public interface IUnitWork : IDisposable
    {
        IProductoRepository Producto { get; }
        Task Save();
    }
}
