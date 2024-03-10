﻿using Lumen.Invoice.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Invoice.Domain.Entities.Helpers
{
    public class AdministrativeUnit
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<EntityBase>? ListOfInvoices { get; set; } = new List<EntityBase>();
    }
}