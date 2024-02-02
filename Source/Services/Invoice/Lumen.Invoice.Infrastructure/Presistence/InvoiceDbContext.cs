using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Domain.Entities.Helpers;

namespace Lumen.Invoice.Infrastructure.Presistence
{
    class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
            
        }

        //Invoices Tables
        public DbSet<DistrictHeatingInvoice> DistrictHeatingInvoices { get; set; }
        public DbSet<ElectricityInvoice> ElectricityInvoices { get; set; }
        public DbSet<OilHeatingInvoice> OilHeatingInvoices { get; set; }
        public DbSet<WaterSewerInvoice> WaterSewerInvoices { get; set; }
        public DbSet<SolidFuelInvoice> SolidFuelInvoices { get; set; }
        public DbSet<GasInvoice> GasInvoicesInvoices { get; set; }
        
        //Helping Tables

        public DbSet<AdministrativeUnit> AdministrativeUnits { get; set; }  
        public DbSet<HeatDeliveryPoint> HeatDeliveryPoints { get; set; }
    }
}
