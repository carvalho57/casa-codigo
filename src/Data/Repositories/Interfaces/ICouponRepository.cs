using System;
using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface ICouponRepository
    {
        void Add(Coupon newCoupon);
        bool Exist(Coupon newCoupon);
        Coupon GetById(Guid id);
        void Edit(Coupon couponToEdit);
        Coupon GetByCode(string code);
    }
}