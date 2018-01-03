using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaberSitem.Admin.Models
{
    public class LoginViewmodel
    {
        [DisplayName("Kullanıcı Adı")]
        [EmailAddress]
        [StringLength(200)]
        [Required(ErrorMessage = "Kullanıcı Adı Alanı Boş Geçilemez")]
        public string UserName { get; set; }
        [DisplayName("Şifre")]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        public string Password { get; set; }
    }
}
