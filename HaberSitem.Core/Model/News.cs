using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HaberSitem.Core.Model
{
    public class News
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık Alanı Boş Geçilemez")]
        [DisplayName("Başlık")]
        [StringLength(200)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı Boş Geçilemez")]
        [DisplayName("Açıklama")]
        public string Description { get; set; }
       
        [DisplayName("Fotoğraf")]
        [StringLength(200)]
        public string Photo { get; set; }
        [DisplayName("Yayın Tarihi")]
        public DateTime PublishDate { get; set; }
        [DisplayName("Yayında")]
        public bool IsPublished { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime CreateDate { get; set; }
        [StringLength(200)]
        [DisplayName("Oluşturan")]
        public string CreatedBy { get; set; }
        [DisplayName("Güncelleme tarihi")]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Güncelleyen")]
        [StringLength(200)]
        public string UpdateBy { get; set; }

        public int CategoryId { get; set; }
        [DisplayName("Kategori")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
    }
}
