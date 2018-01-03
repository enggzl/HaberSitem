using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberSitem.Core.Model
{
    public class User
    {
        public int Id { get; set; }
        [DisplayName("E-Posta")]
        [EmailAddress]
        [StringLength(200)]
        [Required(ErrorMessage = "E-Posta Alanı Boş Geçilemez")]
        public string Email { get; set; }
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar")]
        [NotMapped]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CretaeDate { get; set; }
        [DisplayName("Oluşturan")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Güncelleyen")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
    }
}
