using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Publish.Core.Entities;
using Publish.Domain.Interfaces;

namespace Publish.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RabbitMQController : ControllerBase
    {
        private readonly IParamRabbitMQService _paramRabbitMQService;

        public RabbitMQController(IParamRabbitMQService paramRabbitMQService)
        {
            _paramRabbitMQService = paramRabbitMQService;
        }

        ///<summary>
        ///Obter lista de parametros de configurações do RabbitMQ.
        ///</summary>        
        [HttpGet]
        public async Task<IActionResult> ObterAsync()
        {
            var paramsRabbitMQ = await _paramRabbitMQService.GetAsync();
            if(paramsRabbitMQ == null)
                return NotFound();

            return Ok(paramsRabbitMQ);
        }

        ///<summary>
        ///Obter configuração por Fila.
        ///</summary>
        ///<param name = 'queue'> Nome da fila </param>
        [HttpGet("byqueue")]
        public async Task<IActionResult> ObterByQueue(string queue)
        {
            var rabbitMQ = await _paramRabbitMQService.GetByQueue(queue);
            if(rabbitMQ == null)
                return NotFound();
            return Ok(rabbitMQ);
        }

        ///<summary>
        ///Inserir RabbitMQ.
        ///</summary>
        [HttpPost]
        public async Task<IActionResult> InserirAsync(ParamsRabbitMQ paramsRabbitMQ)
        {
            await _paramRabbitMQService.Insert(paramsRabbitMQ);
            return Ok();
        }
    }
}