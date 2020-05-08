using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PaymentWeb.Data.Entity;

namespace PaymentWeb.Areas.Payment.Models
{
    public class PaymentDetailsViewModel
    {
        public int? id { get; set; }
        public string cardOwnerName { get; set; }
        public string cardNo { get; set; }
        public DateTime? expireDate { get; set; }
        public string cvv { get; set; }

        public IEnumerable<PaymentDetail> paymentDetails { get; set; }
    }
}
