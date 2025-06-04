using System.ComponentModel.DataAnnotations;

namespace Restaurant.Services.CouponAPI.Model
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public string DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
