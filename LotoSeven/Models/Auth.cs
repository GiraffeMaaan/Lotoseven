using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LotoSeven.Models
{
    public class Auth
    {
        [Display(Name = "ユーザーID")]
        [Required(ErrorMessage = "ユーザーIDは必須入力です。")]
        public string Id { get; set; }

        [Display(Name = "パスワード")]
        [Required(ErrorMessage = "パスワードは必須入力です。")]
        public string Password { get; set; }
    }
}