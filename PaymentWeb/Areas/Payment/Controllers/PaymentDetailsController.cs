using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentWeb.Data;
using PaymentWeb.Services.Interfaces;

namespace PaymentWeb.Areas.Payment.Controllers
{
    public class PaymentDetailsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentDetailsController(IPaymentService _paymentService)
        {
            this._paymentService = _paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UnitViewModel model = new UnitViewModel
            {
                units = await unitService.GetAllUnit()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UnitViewModel model)
        {
            var result = "error";

            Unit unit = new Unit
            {
                Id = model.Id,
                unitName = model.unitName,
                shortOrder = model.shortOrder,
                description = model.description,
                createdAt = DateTime.Now,
                createdBy = User.Identity.Name
            };

            bool data = await unitService.SaveUnit(unit);

            if (data == true)
            {
                result = "success";
            }

            return Json(result);
        }

    }
}