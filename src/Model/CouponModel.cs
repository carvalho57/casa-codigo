using System;
using CasaCodigo.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace CasaCodigo.Models
{
    public class CouponModel : Input
    {        
        public string Code { get; set; }
        public float Percentage { get; set; }
        public DateTime ExpiryDate { get; set; }
        public static implicit operator Coupon(CouponModel model)
        {            
            return new Coupon(model.Code, model.Percentage,model.ExpiryDate);
        }
    }
}