using Moq;
using Microsoft.AspNetCore.Mvc;
using TiendaRopa.Controllers;
using TiendaRopa.Data.Repository.IRepositories;
using TiendaRopa.Models;

namespace TiendaRopa.Tests.Controllers
{
    public class ProductoControllerTests
    {
        private readonly Mock<IUnitWork> _mockUnitWork;
        private readonly ProductoController _controller;

        public ProductoControllerTests()
        {
            _mockUnitWork = new Mock<IUnitWork>();
            _controller = new ProductoController(_mockUnitWork.Object);
        }

        [Fact]
        public async Task GetAll_ListOfProductos()
        {
            var productos = new List<Producto>
            {
                new Producto { Id = 1, Talla = 10, Color = "Rojo", Precio = 100, Descripcion = "Producto 1", Nombre = "Gorro" }
            };
            _mockUnitWork.Setup(repo => repo.Producto.GetAll()).ReturnsAsync(productos);

            var result = await _controller.GetAll();

            var jsonResult = Assert.IsType<JsonResult>(result);
            var jsonValue = jsonResult.Value;
            var dataProperty = jsonValue.GetType().GetProperty("data");
            var dataValue = dataProperty.GetValue(jsonValue, null);
            var productList = Assert.IsAssignableFrom<IEnumerable<Producto>>(dataValue);
            Assert.Equal(productos, productList);
        }

        //[Fact]
        //public async Task Upsert_Post_AddProduct()
        //{
        //    var newProduct = new Producto { Nombre = "Nuevo Producto", Talla = 10, Color = "Verde", Precio = 150, Descripcion = "Descripción del nuevo producto" };
        //    _mockUnitWork.Setup(repo => repo.Producto.Add(It.IsAny<Producto>())).Returns((Producto p) => Task.FromResult(p));

        //    var result = await _controller.Upsert(newProduct);

        //    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //}

        //[Fact]
        //public async Task Upsert_Post_UpdateProduct()
        //{
        //    var existingProduct = new Producto { Id = 1, Nombre = "Producto Existente", Talla = 10, Color = "Rojo", Precio = 100, Descripcion = "Descripción del producto existente" };
        //    _mockUnitWork.Setup(repo => repo.Producto.GetById(existingProduct.Id)).ReturnsAsync(existingProduct);

        //    var result = await _controller.Upsert(existingProduct);

        //    var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //    Assert.Equal("Index", redirectToActionResult.ActionName);
        //}

        [Fact]
        public async Task Delete_Post_RemoveProduct()
        {
            var productToDelete = new Producto { Id = 1, Nombre = "Producto a Eliminar", Talla = 10, Color = "Rojo", Precio = 100, Descripcion = "Descripción del producto a eliminar" };
            _mockUnitWork.Setup(repo => repo.Producto.GetById(productToDelete.Id)).ReturnsAsync(productToDelete);

            var result = await _controller.Delete(productToDelete.Id);

            var jsonResult = Assert.IsType<JsonResult>(result);
            var jsonValue = jsonResult.Value;
            var successProperty = jsonValue.GetType().GetProperty("success");
            var successValue = successProperty.GetValue(jsonValue, null);
            Assert.True((bool)successValue);
        }
    }
}