using Lumen.Invoice.Domain.Interfaces;
using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Invoice.Infrastructure.Repositories
{
    public class InvoiceRepo : IInvoiceRepo
    {
        private readonly InvoiceDbContext _dbContext;

        public InvoiceRepo(InvoiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ElectricityInvoice> GetAllElectricityInvoices()
        {
            var Invoices = _dbContext.ElectricityInvoices.ToList();

            return Invoices;
        }

        public ElectricityInvoice GetElectricityInvoice(int id)
        {
            var Invoice = _dbContext.ElectricityInvoices.FirstOrDefault(invoice => invoice.Id == id);

            return Invoice;
        }

        //TODO: All of the other Invoices

        public string GetNameOfAdministrativeUnit(int id)
        {
            var administrativeUnit = _dbContext.AdministrativeUnits.FirstOrDefault(unit => unit.Id == id);

            return administrativeUnit == null ? "" : administrativeUnit.Name;
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() == 0 ? false : true;
        }
    }
}
