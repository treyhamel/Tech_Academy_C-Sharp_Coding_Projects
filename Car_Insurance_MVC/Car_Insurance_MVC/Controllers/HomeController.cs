﻿using Car_Insurance_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Car_Insurance_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Apply(string firstName, string lastName, string emailAddress, int carYear, string carMake, 
                                    string carModel, int speedingTickets, string dui, string coverageType)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || //string.IsNullOrEmpty(dateOfBirth.ToLongDateString()) ||//
                string.IsNullOrEmpty(carYear.ToString()) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel) || string.IsNullOrEmpty(speedingTickets.ToString()))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (InsuranceQuotesEntities2 db = new InsuranceQuotesEntities2())
                {
                    var application = new Application();
                    application.FirstName = firstName;
                    application.LastName = lastName;
                    application.EmailAddress = emailAddress;
                    //application.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                    application.CarYear = carYear;
                    application.CarMake = carMake;
                    application.CarModel = carModel;
                    application.SpeedingTickets = speedingTickets;
                    application.DUI = dui;
                    application.CoverageType = coverageType;
                    application.Quote = QuoteTotal(carYear, carMake, carModel, speedingTickets, dui, coverageType);

                    db.Applications.Add(application);
                    db.SaveChanges();
                }
            }
            return View("Success");
        }

        public decimal QuoteTotal(int carYear, string carMake, string carModel, int speedingTickets, string dui, string coverageType)
        {
            decimal basePrice = 50m;
            decimal modifyPrice = 0m;
            //TimeSpan age = dateOfBirth.Subtract(DateTime.Now);
            //double ageYears = age.Days / 365;

            //if (ageYears < 18)
            //{
            //    modifyPrice += 100m;
            //}
            //else if (ageYears < 25 && ageYears >= 18)
            //{
            //    modifyPrice += 25m;
            //}
            //else if (ageYears > 100)
            //{
            //    modifyPrice += 25m;
            //}

            if (carYear < 2000)
            {
                modifyPrice += 25m;
            }
            else if (carYear > 2015)
            {
                modifyPrice += 25m;
            }

            if (carMake.ToLower() == "porsche")
            {
                modifyPrice += 25m;
            }
            if (carModel.ToLower() == "911 carrera")
            {
                modifyPrice += 25m;
            }

            // Speeding Tickets:
            modifyPrice += (10 * speedingTickets);
            // Subtotal before % modifications.
            decimal subtotalPrice = basePrice + modifyPrice;


            if (dui.ToLower() == "yes")
            {
                subtotalPrice = subtotalPrice * 1.25m;
            }

            if (coverageType.ToLower() == "full")
            {
                subtotalPrice = subtotalPrice * 1.50m;
            }

            return subtotalPrice;
        }
    }
}