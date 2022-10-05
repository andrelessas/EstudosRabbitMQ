using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Publish.Core.DTOs;
using Publish.Domain.Interfaces;

namespace Publish.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        ///<summary>
        ///Obter listagem de produtos.
        ///</summary>
        [HttpGet]
        public async Task<IActionResult> ObterAsync()
        {
            var products = await _service.GetAll();
            if(!products.Any())
                return NotFound();
            return Ok(products);
        }

        ///<summary>
        ///Obter produto por ID.
        ///</summary>
        ///<param name = 'id'> Id Produto </param>
        [HttpGet("porid")]
        public async Task<IActionResult> ObterPorID(int id)
        {
            var product = await _service.GetById(id);
            if(product == null)
                return NotFound();
            
            return Ok(product);
        }

        ///<summary>
        ///Inserir produto.
        ///</summary>
        ///<param name = 'productDTO'> Dados Produto para inserção </param>
        [HttpPost]
        public async Task<IActionResult> InserirAsync(ProductDTO productDTO)
        {
            await _service.Insert(productDTO);
            return Ok();
        }

        ///<summary>
        ///Enviar Lista de produtos Via RabbitMQ
        ///</summary>
        ///<param name = 'queue'> Nome Fila </param>
        [HttpPost("send")]
        public async Task<IActionResult> SendListProduct(string queue)
        {
            await _service.SendProduct(queue);
            return Ok();
        }

        ///<summary>
        ///Enviar produto por Id
        ///</summary>
        ///<param name = 'queue'> nome da fila </param>
        ///<param name = 'id'> id produto </param>
        [HttpPost("sendByID")]
        public async Task<IActionResult> InserirAsync(string queue, int id)
        {
            await _service.SendProduct(queue,id);
            return Ok();
        }
    }
}