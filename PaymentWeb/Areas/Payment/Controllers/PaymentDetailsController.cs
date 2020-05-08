using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentWeb.Areas.Payment.Controllers
{
    public class PaymentDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}