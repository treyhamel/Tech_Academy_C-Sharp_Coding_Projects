using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceMVC.ViewModels
{
    public class QuotesVm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public decimal Quote { get; set; }
    }
}