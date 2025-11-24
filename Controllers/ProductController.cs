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


        //Actualizar Producto
        [HttpPut]
        [Route("actualizarProducto/{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] ProductModel productUpdated)
        {
            if (productUpdated == null)
            {
                return BadRequest("Los datos del producto no pueden ser nulos.");
            }


            var existingProduct = _context.Product.Find(id);

            if (existingProduct == null)
            {

                return NotFound("producto no encontrado.");
            }


            existingProduct.name = productUpdated.name;
            existingProduct.price = productUpdated.price;
            existingProduct.stock = productUpdated.stock;
        


            try
            {
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el producto: {ex.Message}");
            }



            return Ok(new { success = true, message = "Producto actualizado exitosamente!", result = existingProduct });
        }


        //Eliminar Producto
        [HttpDelete("eliminarProducto/{id}")]
        public IActionResult EliminarProducto(int id)
        {

            var product = _context.Product.FirstOrDefault(u => u.id == id);

            if (product == null)
            {

                return NotFound(new { success = false, message = "producto no encontrado." });
            }


            try
            {
                _context.Product.Remove(product);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el producto: {ex.Message}");
            }

            return Ok(new { success = true, message = "Producto eliminado exitosamente!", result = product });
        }

    }



}
