using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentWeb.Data.Entity
{
    public class PaymentDetail : Base
    {
        [Required]
        [StringLength(30)]
        public string cardOwnerName { get; set; }

        [Required]
        [StringLength(30)]
        public string cardNo { get; set; }

        [Required]
        public DateTime? expireDate { get; set; }

        [Required]
        [StringLength(20)]
        public string cvv { get; set; }

    }

}
