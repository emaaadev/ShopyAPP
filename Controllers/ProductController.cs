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
    }

}
