using Lumen.Invoice.Domain.Entities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumen.Invoice.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? InvoiceNumber { get; set; }
        public AdministrativeUnit? AdministrativeUnit { get; set; }
        public DateTime InitialBillingDate { get; set; }
        public DateTime FinalBillingDate { get; set; }
        public int Status { get; set; }
        public bool EReaderSubmitted { get; set; }
        public int /*User*/ WhoSubmitted { get; set; }
        public int /*User*/ WhoApproved { get; set; }
        public DateTime WhenSubmitted { get; set; }
        public DateTime WhenLastModified { get; set; }
        public string? SubmitterComment { get; set; }
        public string? ApproverComment { get; set; }

    }
}
