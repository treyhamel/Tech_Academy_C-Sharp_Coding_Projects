using CarInsuranceMVC.Models;
using CarInsuranceMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (InsuranceQuotesEntities1 db = new InsuranceQuotesEntities1())
            {
                var applications = db.Applications.ToList();
                var applicationsVms = new List<QuotesVm>();
                foreach (var application in applications)
                {
                    var quotesVm = new QuotesVm();
                    quotesVm.FirstName = application.FirstName;
                    quotesVm.LastName = application.LastName;
                    quotesVm.EmailAddress = application.EmailAddress;
                    quotesVm.Quote = (decimal)application.Quote;
                    applicationsVms.Add(quotesVm);
                }
                return View(applicationsVms);
            }
        }
    }
}