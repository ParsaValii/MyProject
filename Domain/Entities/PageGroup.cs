using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PageGroup
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "required")]
        [MaxLength(150)]
        public string GroupTitle { get; set; }

        public IList<Page>? Pages { get; set; }
    }
}
