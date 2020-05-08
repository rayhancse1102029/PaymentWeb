using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentWeb.Data.Entity;

namespace PaymentWeb.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> SavePaymentDetail(PaymentDetail paymentDetail);
        Task<IEnumerable<PaymentDetail>> GetAllPaymentDetail();
        Task<PaymentDetail> GetPaymentDetailById(int id);
        Task<bool> DeletePaymentDetailById(int id);
    }
}
