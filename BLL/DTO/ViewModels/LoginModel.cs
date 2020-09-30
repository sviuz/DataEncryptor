using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage ="Не указан Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage ="Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string returnURL { get; set; }

    }
}
