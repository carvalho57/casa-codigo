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

        [HttpPut]
        [Route("{id:guid}")]
        public ActionResult<Response> EditCupon(Guid id, CouponModel model)
        {
            var couponToEdit = _couponRepository.GetById(id);

            if (couponToEdit == null)
                return BadRequest(ResponseHelper.CreateResponse("Cupom não encontrado", model.Code));

            if (!couponToEdit.ChangeInfo(model.Code, model.Percentage, model.ExpiryDate))
                return BadRequest(ResponseHelper.CreateResponse("Não foi possível alterar o cupom", couponToEdit.Notifications));

            if (_couponRepository.Exist(couponToEdit))
                return BadRequest(ResponseHelper.CreateResponse("Este cupom já se encontra cadastrado", couponToEdit.Id));

            _couponRepository.Edit(couponToEdit);
            return Ok(ResponseHelper.CreateResponse("Cupom alterado com sucesso"));
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Response> CreateCoupon(CouponModel model)
        {
            var newCoupon = (Coupon)model;

            if (newCoupon.Invalid)
                return BadRequest(ResponseHelper.CreateResponse("Cupom inválido", newCoupon.Notifications));

            if (_couponRepository.Exist(newCoupon))
                return BadRequest(ResponseHelper.CreateResponse("Este cupom ja está cadastrado", newCoupon.Code));

            _couponRepository.Add(newCoupon);

            return Ok(ResponseHelper.CreateResponse("Cupon criado com sucesso", newCoupon.Id));
        }

    }
}