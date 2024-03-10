using AutoMapper;
using Lumen.Invoice.Application.Dtos;
using Lumen.Invoice.Domain.Common;
using Lumen.Invoice.Domain.Entities.Mains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Invoice.Application.Profiles
{
    public class InvoicesProfile: Profile
    {
        public InvoicesProfile()
        {
            //BaseEntity Maps
            CreateMap<EntityBase, EntityBaseReadDto>();
            CreateMap<EntityBaseCreateDto, EntityBase>();

            //ElectricityInvoice Maps
            CreateMap<ElectricityInvoice, ElectricityInvoiceReadDto>()
                .IncludeBase<EntityBase, EntityBaseReadDto>();

            CreateMap<ElectricityInvoiceCreateDto, ElectricityInvoice>()
                .IncludeBase<EntityBaseCreateDto, EntityBase>();

            //TODO: Maps of all other Invoices
        }
    }
}
