using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public class Workflow
    {
        [Key]
        public int WorkflowId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Requestor { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        public double TransactionAmount { get; set; }

        [Required]
        public string Remarks { get; set; }

        public string RequestStatus { get; set; }

        // ** For new record
        public string RequestedBy { get; set; }
        public DateTime RequestedDateTime { get; set; } = DateTime.Now;

        // ** For record processing
        public string ProcessedBy { get; set; }
        public DateTime ProcessedDateTime { get; set; } = DateTime.Now;

    }
}
