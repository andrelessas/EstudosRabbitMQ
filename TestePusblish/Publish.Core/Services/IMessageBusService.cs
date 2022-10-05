using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Publish.Core.Entities;

namespace Publish.Core.Services
{
    public interface IMessageBusService
    {
        IMessageBusService SetConnectionFactory(ParamsRabbitMQ paramsRabbitMQ);
        void Publish(string queue, byte[] data);
    }
}