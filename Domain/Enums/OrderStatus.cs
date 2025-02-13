using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum OrderStatus 
    {
        [Display(Name = "در انتظار پردازش")]
        Pending,      // در انتظار پردازش

        [Display(Name = "اختصاص داده شده به راننده")]
        Assigned,     // اختصاص داده شده به راننده

        [Display(Name = "در حال ارسال")]
        InTransit,    // در حال ارسال

        [Display(Name = "تحویل داده شده")]
        Delivered,    // تحویل داده شده

        [Display(Name = "برگشت خورده")]
        Returned,

        [Display(Name = "لغو شده")]
        Canceled      // لغو شده
    }
}
