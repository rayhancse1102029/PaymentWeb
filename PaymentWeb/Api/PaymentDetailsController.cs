using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentWeb.Data;
using PaymentWeb.Data.Entity;
using PaymentWeb.Services.Interfaces;

namespace PaymentWeb.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentDetailsController(IPaymentService _paymentService)
        {
            this._paymentService = _paymentService;
        }

        // [api/PaymentDetails/SavePaymentDetail]
        [HttpGet]
        public async Task<string> SavePaymentDetail(PaymentDetail paymentDetail)
        {
            string msg = "error";

            if (ModelState.IsValid)
            {
                await _paymentService.SavePaymentDetail(paymentDetail);
                msg = "success";
            }

            return msg;
        }

        // [api/PaymentDetails/GetAllPaymentDetail]
        [HttpGet]
        public async Task<IEnumerable<PaymentDetail>> GetAllPaymentDetail()
        {
            IEnumerable<PaymentDetail> model = await _paymentService.GetAllPaymentDetail();

            return model;
        }

        // [api/PaymentDetails/GetPaymentDetailById]
        [HttpGet("{id}")]
        public async Task<PaymentDetail> GetPaymentDetailById(int id)
        {
            return await _paymentService.GetPaymentDetailById(id);
        }
    }
}