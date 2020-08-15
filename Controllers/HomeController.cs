using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleRequestWorkflow.Models;
using SimpleRequestWorkflow.Models.ViewModels;

namespace SimpleRequestWorkflow.Controllers
{
    public class HomeController : Controller
    {
        private IWorkflowRepository _workflowRepository;

        public HomeController(IWorkflowRepository _workflowRepo)
        {
            this._workflowRepository = _workflowRepo;
        }
        
        public ViewResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ViewResult RequestList(string _requestStatus)
        {
            ViewBag.Title = "My Request List";

            WorkflowRepositoryViewModel _workflowRepositoryViewModel = 
                new WorkflowRepositoryViewModel();
            
            switch (_requestStatus)
            {
                case "All":
                    _workflowRepositoryViewModel.MyWorkflows = this._workflowRepository._MyWorkflows
                        .OrderBy(w => w.WorkflowId);
                    break;
                default:
                    _workflowRepositoryViewModel.MyWorkflows = this._workflowRepository._MyWorkflows
                        .Where(s => s.RequestStatus == _requestStatus)
                        .OrderBy(w => w.WorkflowId);
                    break;
            }

            return View(_workflowRepositoryViewModel);
        }

        public ViewResult Create()
        {
            TempData["processTag"] = "New";
            ViewBag.Title = "New Request";
            return View("Request", new Workflow());
        }

        public ViewResult EditRequest(int _workflowId)
        {
            if (_workflowId == 0)
            {
                TempData["processTag"] = "New";
                return this.Create();
            }
            else
            {
                TempData["processTag"] = "For Processing";
                ViewBag.Title = "Edit Request";
                return View("Request", this._workflowRepository._MyWorkflows
                    .FirstOrDefault(w => w.WorkflowId == _workflowId));
            }
        }

        [HttpPost]
        public IActionResult EditRequest(Workflow _workflow, string _status)
        {
            if (ModelState.IsValid)
            {
                string _workflowStatus = (_status == "" || _status == null ? "New" : _status);

                this._workflowRepository.SaveRequest(_workflow, _workflowStatus);

                switch (_workflowStatus)
                {
                    case "New":
                        TempData["returnMessage"] = $"{_workflow.Title} has been submitted!";
                        break;
                    default:
                        TempData["returnMessage"] = $"{_workflow.Title} has been {_workflowStatus}!";
                        break;
                }

                //this.ClearProcessTag();

                return RedirectToAction("RequestList");
            }
            else
            {
                return View(_workflow);
            }
        }

        public void ClearProcessTag()
        {
            // ** Clear Process Tag
            TempData["processTag"] = null;
        }

        public ViewResult RequestView(int _workflowId, string _requestStatus)
        {
            ViewBag.Title = "View Request Details";

            switch (_requestStatus)
            {
                case "New":
                    TempData["processTag"] = "For Processing";
                    break;
                default:
                    TempData["processTag"] = _requestStatus;
                    break;
            }

            return View(new WorkflowRepositoryViewModel
            {
                MyWorkflows = this._workflowRepository._MyWorkflows
                    .Where(w => w.WorkflowId == _workflowId)
            });
        }
        
    }
}
