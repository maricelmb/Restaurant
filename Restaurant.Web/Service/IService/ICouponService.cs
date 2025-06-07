using Restaurant.Services.CouponAPI.Model.Dto;
using Restaurant.Web.Models;
using CouponDto = Restaurant.Web.Models.CouponDto;
using ResponseDto = Restaurant.Web.Models.ResponseDto;

namespace Restaurant.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponAsync();

        Task<ResponseDto?> GetCouponByIdAsync(int id);

        Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto);

        Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto);

        Task<ResponseDto?> DeleteCouponsAsync(int id);

    }
}
