using Microsoft.AspNetCore.Mvc;
using multishop.Discount.Dtos.Coupon;
using multishop.Discount.Services.DiscountCoupon;

namespace multishop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountCouponsController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCoupons()
        {
            var values = await _discountCouponService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var value = await _discountCouponService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto coupon)
        {
            await _discountCouponService.CreateDiscountCouponAsync(coupon);
            return Ok("İndirim Kupon Başarılı Bir Şekilde Oluşturuldu");    
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("İndirim Kupon Başarılı Bir Şekilde Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto discountCoupon)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(discountCoupon);
            return Ok("İndirim Kupon Başarılı Bir Şekilde Güncellendi");
        }
    }
}
