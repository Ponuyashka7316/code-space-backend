using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public  class TableRequest
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
