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
                }
                else
                {
                    var objProducto = await _unitWork.Producto.GetById(producto.Id);
                    _unitWork.Producto.Update(producto);
                }
                await _unitWork.Save();
                return View("Index");
            }
            return View(producto);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
