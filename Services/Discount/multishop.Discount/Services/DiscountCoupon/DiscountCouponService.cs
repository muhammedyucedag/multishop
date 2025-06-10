using Dapper;
using multishop.Discount.Context;
using multishop.Discount.Dtos.Coupon;

namespace multishop.Discount.Services.DiscountCoupon;

public class DiscountCouponService : IDiscountCouponService
{
    private readonly DapperContext _context;

    public DiscountCouponService(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "SELECT * FROM dbo.Coupons";
        using (var connection = _context.CreateDbConnection())
        {
            var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code, Rate, IsActive, ValidDate) values (@code, @rate, @isActive, @validDate)";

        var parameters = new DynamicParameters();
        parameters.Add("@code", createCouponDto.Code);
        parameters.Add("@rate", createCouponDto.Rate);
        parameters.Add("@isActive", createCouponDto.IsActive);
        parameters.Add("@validDate", createCouponDto.ValidDate);

        using (var connection = _context.CreateDbConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        string query = "Update Coupons Set Code=@code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate Where Id=@id";
            
        var parameters = new DynamicParameters();
        parameters.Add("@code", updateDiscountCouponDto.Code);
        parameters.Add("@rate", updateDiscountCouponDto.Rate);
        parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
        parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);
        parameters.Add("@id", updateDiscountCouponDto.Id);

        using (var connection = _context.CreateDbConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "delete from Coupons where Id=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);

        using (var connection = _context.CreateDbConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = "SELECT * FROM dbo.Coupons WHERE Id=@id";
        var parameters = new DynamicParameters();
        parameters.Add("@id", id);
        
        using (var connection = _context.CreateDbConnection())
        {
            var values = await connection.QueryFirstAsync<GetByIdDiscountCouponDto>(query, parameters);
            return values;
        }
    }
}