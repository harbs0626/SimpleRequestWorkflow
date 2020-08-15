using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleRequestWorkflow.Models;
using SimpleRequestWorkflow.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleRequestWorkflow.Controllers
{
    public class AdminController : Controller
    {
        private ITransactionTypeRepository _transactionTypeRepository;

        public AdminController(ITransactionTypeRepository _transactionTypeRepo)
        {
            this._transactionTypeRepository = _transactionTypeRepo;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        public ViewResult TransactionTypeList()
        {
            ViewBag.Title = "Transaction Type List";
            return View(new TransactionTypeRepositoryViewModel
            {
                TransactionTypes = this._transactionTypeRepository._TransactionTypes
                    .OrderBy(t => t.TransactionTypeId)
            });
        }

        public ViewResult TranTypeCreate()
        {
            ViewBag.Title = "New Transaction Type";
            return View("Maintenance\\TranTypeCreate", new TransactionType());
        }

        public ViewResult EditRecord(int? _transactionTypeId)
        {
            if (_transactionTypeId == 0)
            {
                TempData["processTag"] = "New";
                return this.TranTypeCreate();
            }
            else
            {
                TempData["processTag"] = "For Editing";
                ViewBag.Title = "Edit Transaction Type";
                return View("Maintenance\\TranTypeCreate", this._transactionTypeRepository._TransactionTypes
                    .FirstOrDefault(t => t.TransactionTypeId == _transactionTypeId));
            }
        }

        [HttpPost]
        public IActionResult TranTypeEdit(TransactionType _transactionType)
        {
            if (ModelState.IsValid)
            {
                if (TempData["processTag"] != null)
                {
                    string _transactionTypeStatus = TempData["processTag"].ToString();

                    this._transactionTypeRepository.SaveTransactionType(_transactionType);

                    switch (_transactionTypeStatus)
                    {
                        case "New":
                            TempData["returnMessage"] = $"{_transactionType.Title} has been added!";
                            break;
                        default:
                            TempData["returnMessage"] = $"{_transactionType.Title} has been {_transactionTypeStatus}!";
                            break;
                    }
                }

                this.ClearProcessTag();

                return RedirectToAction("TranTypeList");
            }
            else
            {
                return View(_transactionType);
            }
        }

        public void ClearProcessTag()
        {
            // ** Clear Process Tag
            TempData["processTag"] = null;
        }

        public ViewResult TranTypeView(int? _transactionTypeId)
        {
            ViewBag.Title = "View Transaction Type Details";
            return View(new TransactionTypeRepositoryViewModel
            {
                TransactionTypes = this._transactionTypeRepository._TransactionTypes
                    .Where(t => t.TransactionTypeId == _transactionTypeId)
            });
        }


    }
}
