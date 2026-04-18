
using Microsoft.AspNetCore.Mvc;
using SystemLab.DTOs;
using SystemLab.Infrastructure;
using SystemLab.Models;
using SystemLab.Services;

namespace SystemLab.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProdutoController : ControllerBase
    {

        private readonly ProdutoService _service;
        private readonly FilaPedidos _pedidos;

        public ProdutoController(ProdutoService service, FilaPedidos pedidos)
        {
            _service = service;
            _pedidos = pedidos;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _service.GetProdutos();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Valor = dto.Valor
            };

            _service.Create(produto);
            _pedidos.Fila.Enqueue($"Pedido criado em {DateTime.Now}");
            return Created("", produto);


        }

        [HttpGet("teste-retry")]
        public IActionResult TesteRetry()
        {
            _service.SimularChamadaExternaComRetry();

            return Ok("Finalizado");
        }


    }
}