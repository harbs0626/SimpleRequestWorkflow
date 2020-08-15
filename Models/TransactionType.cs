using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        public string Title { get; set; }

        public string Code { get; set; }

        public decimal MinimumLimit { get; set; }

        public decimal MaximumLimit { get; set; }

        // ** For new record
        public string AddedBy { get; set; }
        public DateTime AddedDateTime { get; set; } = DateTime.Now;

        // ** For record editing
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

    }
}
