using Roberthalf.Models;
using Roberthalf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roberthalf.Repository
{
   public interface IInvoice
    {
        Task<List<InvoiceViewModel>> GetAllInvoice();

        Task<InvoiceViewModel> GetInvoice(int Id);

        Task<int> CreateInvoice(Invoice model);
    }
}
