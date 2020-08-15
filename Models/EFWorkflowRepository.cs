using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRequestWorkflow.Models
{
    public class EFWorkflowRepository : IWorkflowRepository
    {
        private ApplicationDbContext _context;

        public EFWorkflowRepository(ApplicationDbContext _ctx)
        {
            this._context = _ctx;
        }

        public IQueryable<Workflow> _MyWorkflows => this._context.Workflows;

        public void SaveRequest(Workflow _workflow, string _workflowStatus)
        {
            if (_workflow.WorkflowId == 0)
            {
                this._context.Workflows.Add(_workflow);
            }
            else
            {
                Workflow _itemEntry = this._context.Workflows
                    .FirstOrDefault(item => item.WorkflowId == _workflow.WorkflowId);

                if (_itemEntry != null)
                {
                    _itemEntry.Title = _workflow.Title;
                    _itemEntry.Requestor = _workflow.Requestor;
                    _itemEntry.TransactionType = _workflow.TransactionType;
                    _itemEntry.TransactionAmount = _workflow.TransactionAmount;
                    _itemEntry.Remarks = _workflow.Remarks;
                    _itemEntry.RequestStatus = _workflowStatus;

                    _itemEntry.ProcessedBy = _workflow.ProcessedBy;
                    _itemEntry.ProcessedDateTime = _workflow.ProcessedDateTime;

                    _itemEntry.Comments = _workflow.Comments;
                }
            }

            this._context.SaveChanges();
        }
    }

}
