using Publish.Core.Entities;
using Publish.Core.Services;
using RabbitMQ.Client;

namespace Publish.Data.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private ConnectionFactory _factory;

        public IMessageBusService SetConnectionFactory(ParamsRabbitMQ paramsRabbitMQ)
        {
            _factory = new ConnectionFactory
            {
                HostName = paramsRabbitMQ.Host,
                UserName = paramsRabbitMQ.User,
                Password = paramsRabbitMQ.PassWord,                
            };

            return this;
        }

        public void Publish(string queue, byte[] data)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: data);
                }
            }
        }
    }
}