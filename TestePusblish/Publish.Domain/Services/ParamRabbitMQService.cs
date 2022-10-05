using Publish.Core.Entities;
using Publish.Core.Interfaces;
using Publish.Domain.Interfaces;

namespace Publish.Domain.Services
{
    public class ParamRabbitMQService : IParamRabbitMQService
    {
        private readonly IParamRabbitMQRepository _paramRabbitMQRepository;

        public ParamRabbitMQService(IParamRabbitMQRepository paramRabbitMQRepository)
        {
            _paramRabbitMQRepository = paramRabbitMQRepository;
        }
        public async Task<IEnumerable<ParamsRabbitMQ>> GetAsync()
        {
            return await _paramRabbitMQRepository.GetAll();
        }

        public async Task<ParamsRabbitMQ> GetByQueue(string queue)
        {
            return await _paramRabbitMQRepository.GetRabbitMQConfig(queue);
        }

        public async Task Insert(ParamsRabbitMQ paramsRabbitMQ)
        {
            await _paramRabbitMQRepository.Insert(paramsRabbitMQ);
        }
    }
}