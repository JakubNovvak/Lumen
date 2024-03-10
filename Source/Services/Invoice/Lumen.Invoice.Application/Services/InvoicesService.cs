using AutoMapper;
using Lumen.Invoice.Application.Dtos;
using Lumen.Invoice.Domain.Entities.Mains;
using Lumen.Invoice.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Invoice.Application.Services
{
    public class InvoicesService : IInvoicesService
    {
        private readonly IInvoiceRepo _repo;
        private readonly IMapper _mapper;

        public InvoicesService(IMapper mapper, IInvoiceRepo repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<ElectricityInvoiceReadDto> GetAllElectricityInvoices()
        {
            var electricityInvoices = _repo.GetAllElectricityInvoices();

            if (electricityInvoices == null)
                throw new ArgumentNullException();

            if (!electricityInvoices.Any())
                throw new KeyNotFoundException();

            var electricityInvoicesReadDto = _mapper.Map<IEnumerable<ElectricityInvoiceReadDto>>(electricityInvoices);

            return electricityInvoicesReadDto;
        }
    }
}
