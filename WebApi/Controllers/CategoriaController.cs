using Core.Entities;
using Core.Interfaces;
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
    public class CategoriaController : ControllerBase
    {
        private readonly IGenericRepository<Categoria> _categoriaRepository;
        public CategoriaController(IGenericRepository<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> GetCategoriaAll()
        {
            var productos = await _categoriaRepository.GetAllAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaId(int id)
        {
            return await _categoriaRepository.GetByIdAsync(id);

        }
    }
}
