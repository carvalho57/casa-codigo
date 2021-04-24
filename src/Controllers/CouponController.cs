using System;
using CasaCodigo.Data.Repositories;
using CasaCodigo.Entities;
using CasaCodigo.Helpers;
using CasaCodigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CasaCodigo.Controller 
{
    [ApiController]
    [Route("[controller]")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponRepository _couponRepository;

        public CouponController(ICouponRepository couponRepository)
        {
            _couponRepository = couponRepository;
        }

        public ActionResult GetAction()
        {
            return Ok(DateTime.UtcNow);
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Response> CreateCoupon(CouponModel model)
        {
            var newCoupon = (Coupon)model;

            if(newCoupon.Invalid)
                return BadRequest(ResponseHelper.CreateResponse("Cupom inválido", newCoupon.Notifications));

            if(_couponRepository.Exist(newCoupon))
                return BadRequest(ResponseHelper.CreateResponse("Este cupom ja está cadastrado", newCoupon.Code));

            _couponRepository.Add(newCoupon);

            return Ok(ResponseHelper.CreateResponse("Cupon criado com sucesso"));
        }

    }
}