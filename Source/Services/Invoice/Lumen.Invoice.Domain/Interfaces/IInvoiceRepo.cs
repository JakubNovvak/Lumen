using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Lumen.Invoice.Domain.Common;
using Lumen.Invoice.Domain.Entities;
using Lumen.Invoice.Domain.Entities.Mains;

namespace Lumen.Invoice.Domain.Interfaces
{
    public interface IInvoiceRepo
    {
        bool SaveChanges();
        IEnumerable<ElectricityInvoice> GetAllElectricityInvoices();
        ElectricityInvoice GetElectricityInvoice(int id);
        string GetNameOfAdministrativeUnit(int id);
    }
}