using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TiendaRopa.Data.Repository.IRepositories;
using TiendaRopa.Models;

namespace TiendaRopa.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IUnitWork _unitWork;

        public ProductoController(IUnitWork unitWork)
        {
            _unitWork = unitWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var all = await _unitWork.Producto.GetAll();
            return Json(new { data = all });
        }

        public async Task<IActionResult> Upsert(int? id)
        {

            Producto producto = new Producto();
            if (id == null)
            {
                return View(producto);
            }
            else
            {
                producto = await _unitWork.Producto.GetById(id.GetValueOrDefault());
                if (producto == null)
                {
                    return NotFound();
                }
                return View(producto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (producto.Id == 0)
                {
                    await _unitWork.Producto.Add(producto);
                    await _unitWork.Save();
                    return RedirectToAction("Index"); // Redirigir después de agregar un nuevo producto
                }
                else
                {
                    var objProducto = await _unitWork.Producto.GetById(producto.Id);
                    _unitWork.Producto.Update(producto);
                    await _unitWork.Save();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var productoDb = await _unitWork.Producto.GetById(id);
            if (productoDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Producto" });
            }

            _unitWork.Producto.Remove(productoDb);
            await _unitWork.Save();
            return Json(new { success = true, message = "Producto borrado correctamente" });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
