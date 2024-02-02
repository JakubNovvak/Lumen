using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lumen.Invoice.Domain.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public string AdministrativeUnit { get; set; }
        public DateTime InitialBillingDate { get; set; }
        public DateTime FinalBillingDate { get; set; }
        private int Status { get; set; }
        private bool EReaderSubmitted { get; set; }
        private int /*User*/ WhoSubmitted { get; set; }
	    private int /*User*/ WhoApproved { get; set; }
        private DateTime WhenSubmitted { get; set; }
        private DateTime WhenLastModified { get; set; }
        private string? SubmitterComment { get; set; }
        private string? ApproverComment { get; set; }

    }
}
