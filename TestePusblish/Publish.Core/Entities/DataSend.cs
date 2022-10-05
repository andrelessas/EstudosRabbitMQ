using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publish.Core.Entities
{
    public class DataSend
    {
        public string Queue { get; set; }
        public object Data { get; set; }
    }
}