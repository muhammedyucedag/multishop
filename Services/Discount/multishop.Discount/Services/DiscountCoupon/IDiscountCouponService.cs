using multishop.Discount.Dtos.Coupon;

namespace multishop.Discount.Services.DiscountCoupon;

public interface IDiscountCouponService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
    Task DeleteDiscountCouponAsync(int id);
    Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
}