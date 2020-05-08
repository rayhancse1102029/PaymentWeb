using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentWeb.Areas.Payment.Models
{
    public class PymentDetailsViewModel
    {
        public string cardOwnerName { get; set; }
        public string cardNo { get; set; }
        public DateTime? expireDate { get; set; }
        public string cvv { get; set; }
    }
}
