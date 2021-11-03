using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roberthalf.ViewModel
{
    public class InvoiceViewModel
    {

        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public bool Active { get; set; }
    }
}
