﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Services.CouponAPI.Data;
using Restaurant.Services.CouponAPI.Model;
using Restaurant.Services.CouponAPI.Model.Dto;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get() 
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.Result = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("id:int")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponId == id);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.Result = false;
                _response.Message = ex.Message;
                
            }

            return _response;
        }
    }
}
