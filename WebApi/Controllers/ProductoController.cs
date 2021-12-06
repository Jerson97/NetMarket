using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        public ProductoController(IGenericRepository<Producto> productoRepository)
        {
            _productoRepository = productoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoWithCategoriaAndMarcaSpecification();

            var productos = await _productoRepository.GetAllWithSpec(spec);
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProductoId(int id)
        {
            //spec = debe incluir lal ogivca de la condicion de la consulta y tambien debe incluir las relaciones entre las entidades
            // la relacion entre Productos y marca, categoria

            var spec = new ProductoWithCategoriaAndMarcaSpecification(id);
            return await _productoRepository.GetByIdWithSpec(spec);
            
        }
    }
}
