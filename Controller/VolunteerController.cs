using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversWeb.Models;
using System.Collections.Generic;

namespace GiftOfTheGiversWeb.Controllers
{
    public class VolunteerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private static List<Volunteer> volunteers = new List<Volunteer>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Volunteer volunteer)
        {
            volunteers.Add(volunteer);
            ViewBag.Message = "Thank you for registering your interest!";
            return View("Index");
        }

        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Employee")]
        public IActionResult ViewVolunteers()
        {
            return View(volunteers);
        }
    }
}