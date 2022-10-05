using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Publish.Core.Entities;

namespace Publish.Data.Mappings
{
    public class ParamsRabbitMQMapping : IEntityTypeConfiguration<ParamsRabbitMQ>
    {
        public void Configure(EntityTypeBuilder<ParamsRabbitMQ> builder)
        {
            builder.HasKey(p => p.Queue);
        }
    }
}