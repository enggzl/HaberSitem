using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberSitem.Core.Model
{
    public class Comments
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yorum Alanı Boş Geçilemez")]
        [DisplayName("Yorum")]
        public string Description { get; set; }

        public int UserId { get; set; }
        [DisplayName("Kullanıcı")]
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
