using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemLab.DTOs;
using SystemLab.Models;
using SystemLab.Services;

namespace SystemLab.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service=service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos= _service.GetProdutos();
            return Ok(produtos);
        }

    [HttpPost]
    public IActionResult Post(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Nome=dto.Nome,
                Valor=dto.Valor
            };

            _service.Create(produto);
            return Created("",produto);
        }
        
        
    }
}