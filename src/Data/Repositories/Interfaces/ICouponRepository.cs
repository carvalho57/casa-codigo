using CasaCodigo.Entities;

namespace CasaCodigo.Data.Repositories
{
    public interface ICouponRepository
    {
        void Add(Coupon newCoupon);
        bool Exist(Coupon newCoupon);
    }
}