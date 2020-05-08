using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentWeb.Areas.Payment.Models;
using PaymentWeb.Data;
using PaymentWeb.Data.Entity;
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
            PaymentDetailsViewModel model = new PaymentDetailsViewModel
            {
                paymentDetails = await _paymentService.GetAllPaymentDetail()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PaymentDetailsViewModel model)
        {
            var result = "error";

            PaymentDetail payment = new PaymentDetail
            {
                Id = (int)model.id,
                cardOwnerName = model.cardOwnerName,
                cardNo = model.cardNo,
                expireDate = model.expireDate,
                cvv = model.cvv
            };

            bool data = await _paymentService.SavePaymentDetail(payment);

            if (data == true)
            {
                result = "success";
            }

            return Json(result);
        }

    }
}