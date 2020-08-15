using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleRequestWorkflow.Models;

namespace SimpleRequestWorkflow.Models.ViewModels
{
    public class WorkflowRepositoryViewModel
    {
        public IEnumerable<Workflow> MyWorkflows { get; set; }

    }
}
