using Microsoft.AspNetCore.Mvc;
using GiftOfTheGiversWeb.Models;
using System;

namespace GiftOfTheGiversWeb.Controllers
{
    public class DonationController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessDonation(Donation donation)
        {
            string certificateNumber = $"TAX-{DateTime.UtcNow:yyyyMMdd}-{new Random().Next(1000, 9999)}";

            ViewBag.Certificate = certificateNumber;
            ViewBag.Message = $"Thank you for your {donation.DonationType?.ToLower()} donation of {donation.Amount} {donation.Currency}.";

            return View("Success");
        }
    }
}