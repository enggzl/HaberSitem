using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HaberSitem.Core.Model
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez")]
        [DisplayName("Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Oluşturan")]
        [StringLength(200)]
        public string CreatedBy { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Güncelleyen")]
        [StringLength(200)]
        public string UpdatedBy { get; set; }

        //---virtualde koyabilirsin ama mecburi değil
        public virtual ICollection<News> News { get; set; }

    }
}
