using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Publish.Core.Entities;

namespace Publish.Core.Interfaces
{
    public interface IParamRabbitMQRepository
    {
        Task<ParamsRabbitMQ> GetRabbitMQConfig(string queue);
        Task<IEnumerable<ParamsRabbitMQ>> GetAll();
        Task Insert(ParamsRabbitMQ paramsRabbitMQ);
    }
}