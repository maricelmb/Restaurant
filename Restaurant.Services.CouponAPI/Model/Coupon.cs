namespace Restaurant.Services.CouponAPI.Model
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public string DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
