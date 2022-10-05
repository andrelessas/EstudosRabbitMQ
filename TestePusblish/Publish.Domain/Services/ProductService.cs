using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Publish.Core.DTOs;
using Publish.Core.Entities;
using Publish.Core.Interfaces;
using Publish.Core.Services;
using Publish.Domain.Interfaces;

namespace Publish.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IParamRabbitMQRepository _paramsRabbitMQRepository;
        private readonly IMessageBusService _messageBus;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, 
            IParamRabbitMQRepository paramRabbitMQRepository,
            IMessageBusService messageBus,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _paramsRabbitMQRepository = paramRabbitMQRepository;
            _messageBus = messageBus;
            _mapper = mapper;
        }
        public Task<IEnumerable<Product>> GetAll()
        {
            return _productRepository.GetAsync();
        }

        public Task<Product> GetById(int id)
        {
            return _productRepository.GetByIdAsync(id);
        }

        public async Task Insert(ProductDTO productDTO)
        {
            await _productRepository.InsertAsync(_mapper.Map<Product>(productDTO));
        }

        public async Task SendProduct(string queue)
        {
            var paramsRabbitMQ = await _paramsRabbitMQRepository.GetRabbitMQConfig(queue);
            if(paramsRabbitMQ == null)
                throw new Exception("Fila não encontrada.");

            var products = await _productRepository.GetAsync();
            if(!products.Any())
                throw new Exception("Nenhum produto encontrado.");

            var productJson = JsonSerializer.Serialize(products);
            var productByte = Encoding.UTF8.GetBytes(productJson);

            _messageBus.SetConnectionFactory(paramsRabbitMQ)
                .Publish(queue,productByte);
        }

        public async Task SendProduct(string queue, int id)
        {
            var paramsRabbitMQ = await _paramsRabbitMQRepository.GetRabbitMQConfig(queue);
            if(paramsRabbitMQ == null)
                throw new Exception("Fila não encontrada.");

            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
                throw new Exception("Nenhum produto encontrado.");

            var productJson = JsonSerializer.Serialize(product);
            var productByte = Encoding.UTF8.GetBytes(productJson);

            _messageBus.SetConnectionFactory(paramsRabbitMQ)
                .Publish(queue,productByte);
        }
    }
}