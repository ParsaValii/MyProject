using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Page
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "required")]
        public int PageGroupId { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "required")]
        [MaxLength(250)]
        public string Title { get; set; }


        [Display(Name = "خلاصه")]
        [Required(ErrorMessage = "required")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string ShortDiscription { get; set; }


        [Display(Name = "متن")]
        [Required(ErrorMessage = "required")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }


        [Display(Name = "بازدید")]
        public int Visit { get; set; }


        [Display(Name = "تصویر")]
        public string ImageName { get; set; }


        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }


        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }



        public PageGroup PageGroup { get; set; }
        public List<PageComment> PageComments { get; set; }
    }
}
