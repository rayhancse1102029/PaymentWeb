using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentWeb.Data.Entity
{
    public class ApplicationUser:IdentityUser
    {
        public string IdentityRoleId { get; set; }
        public IdentityRole IdentityRole { get; set; }
        
        public int? isActive { get; set; }

        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string createdBy { get; set; }

        public bool isLocked { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string updatedBy { get; set; }
    }
}
