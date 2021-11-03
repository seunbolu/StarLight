using System;
using System.Collections.Generic;

#nullable disable

namespace Roberthalf.Models
{
    public partial class Invoice
    {
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public bool Active { get; set; }
    }
}
