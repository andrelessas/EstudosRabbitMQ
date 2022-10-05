using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Publish.Core.DTOs;
using Publish.Core.Entities;

namespace Publish.Domain.Configuration
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<ProductDTO,Product>()
                .ReverseMap();
        }
    }
}