using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SagaExample.Entities
{
    public class Order
    {
        public string Payment { get; set; }
        public string Stock { get; set; }
        public string Delivery { get; set; }
    }
}
