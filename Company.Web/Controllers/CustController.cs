using Company.Core;
using Company.Infra.Interfaces;
using Company.Infra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.Web.Controllers
{
    public class CustController : Controller
    {
        // GET: Cust
        ICustomer crepo;
        public CustController(ICustomer ctemp)
        {
            this.crepo = ctemp;
        }
        public ActionResult Index()
        {
            return View(this.crepo.GetAll());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer rec)
        {
            if (ModelState.IsValid)
            {
                this.crepo.Add(rec);
                return RedirectToAction("Index");
            }

            return View(rec);
        }
    }
}