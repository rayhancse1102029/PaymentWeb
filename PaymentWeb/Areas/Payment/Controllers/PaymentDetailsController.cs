using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaymentWeb.Data;
using PaymentWeb.Data.Entity;

namespace PaymentWeb.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class PaymentDetailsController : Controller
    {
        private readonly PaymentDbContext _context;

        public PaymentDetailsController(PaymentDbContext context)
        {
            _context = context;
        }

        // GET: Payment/PaymentDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaymentDetails.ToListAsync());
        }

        // GET: Payment/PaymentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // GET: Payment/PaymentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payment/PaymentDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cardOwnerName,cardNo,expireDate,cvv,Id,isDelete,createdAt,updatedAt,createdBy,updatedBy")] PaymentDetail paymentDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDetail);
        }

        // GET: Payment/PaymentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            return View(paymentDetail);
        }

        // POST: Payment/PaymentDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("cardOwnerName,cardNo,expireDate,cvv,Id,isDelete,createdAt,updatedAt,createdBy,updatedBy")] PaymentDetail paymentDetail)
        {
            if (id != paymentDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentDetailExists(paymentDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paymentDetail);
        }

        // GET: Payment/PaymentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentDetail == null)
            {
                return NotFound();
            }

            return View(paymentDetail);
        }

        // POST: Payment/PaymentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentDetailExists(int id)
        {
            return _context.PaymentDetails.Any(e => e.Id == id);
        }
    }
}
