using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public interface IWorkflowRepository
    {
        IQueryable<Workflow> _MyWorkflows { get; }

        void SaveRequest(Workflow _workflow, string _workflowStatus);

    }
}
