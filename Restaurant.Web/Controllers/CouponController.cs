using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Restaurant.Web.Models;
using Restaurant.Web.Service.IService;

namespace Restaurant.Web.Controllers
{
    public class CouponController(ICouponService couponService) : Controller
    {
        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();

            ResponseDto? response = await couponService.GetAllCouponAsync();

            if (response != null && response.IsSuccess == true)
            {
                list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
            }
            else 
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CouponCreate()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await couponService.CreateCouponsAsync(model);

                if (response != null && response.IsSuccess == true)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(model);
        }

        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? response = await couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess == true)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto model)
        {
            ResponseDto? response = await couponService.DeleteCouponsAsync(model.CouponId);

            if (response != null && response.IsSuccess == true)
            {
                TempData["success"] = "Coupon deleted successfully";
                return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(model);
        }
    }
}
