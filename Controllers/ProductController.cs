using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopyAPP.Context;
using ShopyAPP.Models;

namespace ShopyAPP.Controllers
{
    [Route("api/shopy/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopyAPPContext _context;

        public ProductController(ShopyAPPContext context)
        {
            _context = context;
        }

        //Obtener Productos
        [HttpGet]
        [Route("obtenerProductos")]
        public IEnumerable<ProductModel> GetProductos()
        {
            return _context.Product.ToList();
        }


        //Crear Producto
        [HttpPost]
        [Route("crearProducto")]
        public IActionResult CrearProducto([FromBody] ProductModel nuevoProducto)
        {
            if (nuevoProducto == null)
            {
                return BadRequest("El producto no puede ser nulo.");
            }

            var product = new ProductModel
            {
                name = nuevoProducto.name,
                price = nuevoProducto.price,
                stock = nuevoProducto.stock
        
            };


            try
            {
                _context.Product.Add(product);


                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el producto: {ex.Message}");
            }

            return Ok(new { success = true, message = "Producto actualizado exitosamente!", result = product });
        }

    }

}
