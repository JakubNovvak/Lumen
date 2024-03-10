using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lumen.Invoice.Domain.Entities.Helpers;
using Lumen.Invoice.Domain.Entities.Mains;


namespace Lumen.Invoice.Infrastructure.Presistence
{
    public static class InvoiceDbContextSeed
    {
        public static void PrepPopulation(IApplicationBuilder app, bool IsProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                if (IsProduction)
                {
                    //TODO: Production stuff
                    SeedDataProduction();
                }
                else
                    SeedDataDevelopment(serviceScope.ServiceProvider.GetService<InvoiceDbContext>());
            }
        }

        private static void SeedDataProduction()
        {
            throw new NotImplementedException();
        }

        private static void SeedDataDevelopment(InvoiceDbContext? InvoiceDbContext)
        {
            if (InvoiceDbContext == null)
                throw new ArgumentNullException();
            

            InvoiceDbContext.AdministrativeUnits.AddRange(
                new AdministrativeUnit() { Name = "MOSIR/Stadion" },
                new AdministrativeUnit() { Name = "MOSIR/Lodowisko" }
                );

            InvoiceDbContext.SaveChanges();

            Console.WriteLine($">[Seed] AdministrativeUnits.Count(): {InvoiceDbContext.AdministrativeUnits.Count()}");

            InvoiceDbContext.ElectricityInvoices.AddRange(
                new ElectricityInvoice() { 
                    InvoiceNumber="12312421",
                    AdministrativeUnit = InvoiceDbContext.AdministrativeUnits.FirstOrDefault(),
                    InitialBillingDate = new DateTime(),
                    FinalBillingDate=new DateTime(),
                    EReaderSubmitted = false,
                    Status = 1,
                    WhenLastModified = new DateTime(),
                    WhenSubmitted = new DateTime(),
                    WhoApproved = 1,
                    WhoSubmitted = 2,
                    ApproverComment = "",
                    SubmitterComment = ""
                },
                new ElectricityInvoice(){
                    InvoiceNumber = "123456789",
                    AdministrativeUnit = InvoiceDbContext.AdministrativeUnits.FirstOrDefault(opt => opt.Id == 2),
                    InitialBillingDate = new DateTime(),
                    FinalBillingDate = new DateTime(),
                    EReaderSubmitted = false,
                    Status = 2,
                    WhenLastModified = new DateTime(),
                    WhenSubmitted = new DateTime(),
                    WhoApproved = 2,
                    WhoSubmitted = 1,
                    ApproverComment = "",
                    SubmitterComment = ""
                }
                );

            InvoiceDbContext.SaveChanges();

            InvoiceDbContext.ElectricityInvoices.ToArray()[0].AdministrativeUnit = InvoiceDbContext.AdministrativeUnits.FirstOrDefault();

            InvoiceDbContext.SaveChanges();

            Console.WriteLine($"{InvoiceDbContext.ElectricityInvoices.ToArray()[0].AdministrativeUnit}");

        }
    }
}
