using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PageComment
    {
        [Key]
        public int ComemntId { get; set; }


        [Display(Name = "خبر")]
        [Required(ErrorMessage = "required")]
        public int PageId { get; set; }


        [Display(Name = "نام")]
        [Required(ErrorMessage = "required")]
        [MaxLength(70)]
        public string Name { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        public string Email { get; set; }


        [Display(Name = "سایت")]
        [MaxLength(200)]
        public string WebSite { get; set; }


        [Display(Name = "کامنت")]
        [Required(ErrorMessage = "required")]
        [MaxLength(500)]
        public string Comment { get; set; }


        [Display(Name = "تاریخ ثبت")]
        public DateTime CreateDate { get; set; }


        public Page Page { get; set; }
    }
}
