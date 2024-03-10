using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lumen.Invoice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        public InvoiceController()
        {

        }

        [HttpGet("/tests/HelloWorld", Name = "HelloWorldAction")]
        public ActionResult TestController()
        {
            return Ok("Hello World!");
        }
    }
}
