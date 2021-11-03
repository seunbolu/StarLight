using Microsoft.AspNetCore.Mvc;
using Roberthalf.Models;
using Roberthalf.Repository;
using Roberthalf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roberthalf.Controllers
{
    [Route("internalapi/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
      private readonly  IInvoice _invoiceRepository;
        public InvoiceController(IInvoice invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // GET:All Invoice
        [HttpGet]
        public async Task<List<InvoiceViewModel>> Get()
        {
            return await _invoiceRepository.GetAllInvoice();
        }

        // GET: api/Invoice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceViewModel>> Get(int id)
        {
            var invoice = await _invoiceRepository.GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }


        [HttpPost]
        public async Task<ActionResult<Invoice>> Post(Invoice model)   
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Active = true;
                    model.CreationTimestamp = DateTime.UtcNow;
                 

                    var Id = await _invoiceRepository.CreateInvoice(model);
                    if (Id > 0)
                        return Ok(Id);


                    
                 return NotFound();
                    
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

    }
}
