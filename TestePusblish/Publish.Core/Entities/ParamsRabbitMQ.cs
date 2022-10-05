using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publish.Core.Entities
{
    public class ParamsRabbitMQ
    {        
        public string Host { get; set; }
        public string User { get; set; }
        public string PassWord { get; set; }
        public string Queue { get; set; }
    }
}