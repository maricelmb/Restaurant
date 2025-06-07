using Restaurant.Web.Models;
using Restaurant.Web.Service.IService;

namespace Restaurant.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService) 
        {
            _baseService = baseService;
        }

        Task<ResponseDto?> ICouponService.CreateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDto?> ICouponService.DeleteCouponsAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDto?> ICouponService.GetAllCouponAsync()
        {
            throw new NotImplementedException();
        }

        Task<ResponseDto?> ICouponService.GetCouponAsync(string couponCode)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDto?> ICouponService.GetCouponByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ResponseDto?> ICouponService.UpdateCouponsAsync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
