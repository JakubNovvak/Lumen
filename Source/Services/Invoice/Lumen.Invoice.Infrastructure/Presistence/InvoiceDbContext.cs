using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Domain.Entities.Helpers;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace Lumen.Invoice.Infrastructure.Presistence
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativeUnit>()
                .HasMany(a => a.ListOfInvoices)
                .WithOne(i => i.AdministrativeUnit)
                .HasForeignKey(i => i.administrativeUnitId)
                .IsRequired(true);
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

        //TODO: public DbSet<HeatDeliveryPoint> HeatDeliveryPoints { get; set; }
    }
}
