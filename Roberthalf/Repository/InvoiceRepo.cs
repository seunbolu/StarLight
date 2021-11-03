using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Roberthalf.Data;
using Roberthalf.Models;
using Roberthalf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roberthalf.Repository
{

    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceRepo : IInvoice
    {

      public readonly ApplicationDbContext db;
        public InvoiceRepo(ApplicationDbContext _db)
        {
            db = _db;
        }

        public async Task<int> CreateInvoice(Invoice model)
        {
            if (db != null)
            {
                await db.Invoices.AddAsync(model);
                await db.SaveChangesAsync();

                return model.InvoiceId;
            }

            return 0;
        }

        public async Task<List<InvoiceViewModel>> GetAllInvoice()
        {
            if (db != null)
            {
                return await(from p in db.Invoices
                             select new InvoiceViewModel
                             {
                                 InvoiceId = p.InvoiceId,
                                 Amount = p.Amount,
                                 CreationTimestamp = p.CreationTimestamp,
                                 Description = p.Description
                             }).ToListAsync();
            }

            return null;
        }

        public async Task<InvoiceViewModel> GetInvoice(int Id)
        {
            if (db != null)
            {
                return await (from p in db.Invoices where p.InvoiceId == Id

                             
                             select new InvoiceViewModel
                             {
                                 InvoiceId = p.InvoiceId,
                                 Amount = p.Amount,
                                 CreationTimestamp= p.CreationTimestamp,
                                 Description= p.Description
                                 
                             }).FirstOrDefaultAsync();
            }

            return null;

         
        }
    }
}
