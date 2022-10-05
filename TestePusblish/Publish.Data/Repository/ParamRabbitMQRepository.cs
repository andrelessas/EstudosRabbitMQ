using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Publish.Core.Entities;
using Publish.Core.Interfaces;
using Publish.Data.Context;

namespace Publish.Data.Repository
{
    public class ParamRabbitMQRepository : IParamRabbitMQRepository
    {
        private readonly MyContext _context;

        public ParamRabbitMQRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ParamsRabbitMQ>> GetAll()
        {
            return await _context.ParamsRabbitMQ.ToListAsync();
        }

        public async Task<ParamsRabbitMQ> GetRabbitMQConfig(string queue)
        {
            return await _context.ParamsRabbitMQ.FirstOrDefaultAsync(x=>x.Queue == queue);
        }

        public async Task Insert(ParamsRabbitMQ paramsRabbitMQ)
        {
            _context.ParamsRabbitMQ.Add(paramsRabbitMQ);
            await _context.SaveChangesAsync();
        }
    }
}