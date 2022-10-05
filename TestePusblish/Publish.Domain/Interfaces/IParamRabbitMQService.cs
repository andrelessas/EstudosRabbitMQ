using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Publish.Core.Entities;

namespace Publish.Domain.Interfaces
{
    public interface IParamRabbitMQService
    {
        Task Insert(ParamsRabbitMQ paramsRabbitMQ);
        Task<IEnumerable<ParamsRabbitMQ>> GetAsync();
        Task<ParamsRabbitMQ> GetByQueue(string queue);
    }
}