using Lumen.Invoice.Application.Dtos;
using Lumen.Invoice.Application.Services;
using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Invoice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;

        public InvoiceController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;
        }

        [HttpGet("/tests/HelloWorld", Name = "HelloWorldAction")]
        public ActionResult TestController()
        {
            return Ok("Hello World!");
        }

        [HttpGet("/tests/ElectricityInvoices", Name = "ElectricityInvoicesTest")]
        public ActionResult<IEnumerable<ElectricityInvoiceReadDto>> GetAllElectricityInvoices()
        {
            try
            {
                var electricityInvoicesReadDto = _invoicesService.GetAllElectricityInvoices();
                return Ok(electricityInvoicesReadDto);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($">[TestsCtrl] There was an error while retrieving the electricity invoices: {ex.Message}");
                return BadRequest($"There was an error while retrieving the electricity invoices: {ex.Message}");
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($">[TestsCtrl] There is no electricity invoices in the database: {ex.Message}");
                return BadRequest($"There is no electricity invoices in the database: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($">[TestsCtrl] There was an unexpected error: {ex.Message}");
                return BadRequest($"There was an unexpected error: {ex.Message}");
            }
        }
    }
}
