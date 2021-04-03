using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProgrammersBlog.Entities.Dtos
{
   public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0}  boş geçilemez")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")]
        [Required(ErrorMessage = "{0}  boş geçilemez")]
        [MaxLength(270, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [Required(ErrorMessage = "{0}  boş geçilemez")]
        [MaxLength(270, ErrorMessage = "{0} {1} karakterden büyük olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz")]
        public string Note { get; set; }

        [DisplayName("Aktifmi")]
        [Required(ErrorMessage = "{0} kısmı  boş geçilemez")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} kısmı  boş geçilemez")]
        public bool IsDeleted { get; set; }
    }
}
