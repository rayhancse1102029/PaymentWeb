using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentWeb.Data;
using PaymentWeb.Data.Entity;
using PaymentWeb.Services.Interfaces;

namespace PaymentWeb.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PaymentDbContext _context;


        public PaymentService(PaymentDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SavePaymentDetail(PaymentDetail paymentDetail)
        {
            if (paymentDetail.id != 0)
            {
                _context.PaymentDetails.Update(paymentDetail);

                await _context.SaveChangesAsync();

                return true;
            }

            await _context.PaymentDetails.AddAsync(paymentDetail);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PaymentDetail>> GetAllPaymentDetail()
        {

            return await _context.PaymentDetails.ToListAsync();
        }

        public async Task<PaymentDetail> GetPaymentDetailById(int id)
        {
            return await _context.PaymentDetails.FindAsync(id);
        }

        public async Task<bool> DeletePaymentDetailById(int id)
        {
            _context.PaymentDetails.Remove(_context.PaymentDetails.Find(id));

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
