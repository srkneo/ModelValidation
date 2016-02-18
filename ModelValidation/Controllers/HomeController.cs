using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelValidation.Models;

namespace ModelValidation.Controllers
{
    public class HomeController : Controller
    {        
        public ViewResult MakeBooking()
        {
            return View(new Appointment { Date = DateTime.Now });
        }

        [HttpPost]
        public ViewResult MakeBooking(Appointment appt)
        {
            if(string.IsNullOrEmpty(appt.ClientName))
            {
                ModelState.AddModelError("ClientName", "Please enter your name");
            }

            if(ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            {
                ModelState.AddModelError("Date", "Please Enter Date in Future");
            }

            if(!appt.TermAccepted)
            {
                ModelState.AddModelError("TermAccepted", "You must accept the terms");
            }

            if(ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }            
        }
	}
}