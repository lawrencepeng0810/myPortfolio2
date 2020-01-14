using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcHtmlHelpers.Models
{
    public class EmployeesNew
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength =3, ErrorMessage = "最少需要3各字元!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}\-?\d{3}\-?\d{3}$", ErrorMessage = "需為 09xx-xxx-xxx")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "請輸入 Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "請輸入 Department")]
        public string Department { get; set; }

        [Required(ErrorMessage = "請輸入 Title")]
        public string Title { get; set; }
    }
}