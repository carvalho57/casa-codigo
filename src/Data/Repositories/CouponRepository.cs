using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaCodigo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaCodigo.Data.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly ApplicationDbContext _context;

        public CouponRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Coupon newCoupon)
        {
            _context.Coupons.Add(newCoupon);
            _context.SaveChanges();
        }

        public void Edit(Coupon couponToEdit)
        {
            _context.Entry(couponToEdit).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Exist(Coupon newCoupon)
        {
            return _context.Coupons.Where(c => c.Id != newCoupon.Id).Any(c => c.Code == newCoupon.Code);
        }

        public Coupon GetByCode(string code)
        {
            return _context.Coupons.AsNoTracking().FirstOrDefault(c => c.Code == code);
        }

        public Coupon GetById(Guid id)
        {
            return _context.Coupons.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
