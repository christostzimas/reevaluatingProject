﻿using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class UserLogin
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "username is required")]
        public string username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }


    }
}
