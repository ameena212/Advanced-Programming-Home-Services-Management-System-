﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectWebApp.Models;

namespace ProjectWebApp.Controllers
{
    public class PaymentStatusController : Controller
    {
        private readonly DBHomeServiceContext _context;

        public PaymentStatusController(DBHomeServiceContext context)
        {
            _context = context;
        }

        // GET: PaymentStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.PaymentStatuses.ToListAsync());
        }

        // GET: PaymentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentStatuses == null)
            {
                return NotFound();
            }

            var paymentStatus = await _context.PaymentStatuses
                .FirstOrDefaultAsync(m => m.PaymentStatusId == id);
            if (paymentStatus == null)
            {
                return NotFound();
            }

            return View(paymentStatus);
        }

        // GET: PaymentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentStatusId,PaymentStatus1")] PaymentStatus paymentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentStatus);
        }

        // GET: PaymentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentStatuses == null)
            {
                return NotFound();
            }

            var paymentStatus = await _context.PaymentStatuses.FindAsync(id);
            if (paymentStatus == null)
            {
                return NotFound();
            }
            return View(paymentStatus);
        }

        // POST: PaymentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentStatusId,PaymentStatus1")] PaymentStatus paymentStatus)
        {
            if (id != paymentStatus.PaymentStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentStatusExists(paymentStatus.PaymentStatusId))
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
            return View(paymentStatus);
        }

        // GET: PaymentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentStatuses == null)
            {
                return NotFound();
            }

            var paymentStatus = await _context.PaymentStatuses
                .FirstOrDefaultAsync(m => m.PaymentStatusId == id);
            if (paymentStatus == null)
            {
                return NotFound();
            }

            return View(paymentStatus);
        }

        // POST: PaymentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentStatuses == null)
            {
                return Problem("Entity set 'DBHomeServiceContext.PaymentStatuses'  is null.");
            }
            var paymentStatus = await _context.PaymentStatuses.FindAsync(id);
            if (paymentStatus != null)
            {
                _context.PaymentStatuses.Remove(paymentStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentStatusExists(int id)
        {
          return _context.PaymentStatuses.Any(e => e.PaymentStatusId == id);
        }
    }
}
