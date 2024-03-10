using Lumen.Invoice.Application.Dtos;

namespace Lumen.Invoice.Application.Services
{
    public interface IInvoicesService
    {
        //TODO: All the rest of needed Invoices
        public IEnumerable<ElectricityInvoiceReadDto> GetAllElectricityInvoices();
    }
}