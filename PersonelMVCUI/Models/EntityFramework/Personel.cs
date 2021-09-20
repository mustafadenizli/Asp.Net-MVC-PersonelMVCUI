//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonelMVCUI.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personel()
        {
            this.ADDRESS = new HashSet<ADDRESS>();
        }
    
        public int Id { get; set; }
        [Display(Name = "Departman Ad�")]
        [Required(ErrorMessage ="Departman Se�iniz...")]
        public Nullable<int> DepartmanId { get; set; }
        [Required(ErrorMessage = "Ad Giriniz...")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad Giriniz...")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Maa� Giriniz...")]
        [Range(2500,8000,ErrorMessage ="Maa� 2500 ile 8000 aras�nda olmal�d�r...")]
        [Display(Name = "Maa�")]
        public Nullable<short> Maas { get; set; }
        [Required(ErrorMessage = "Do�um Tarihi Giriniz...")]
        [Display(Name = "Do�um Tarihi")]
        public Nullable<System.DateTime> DogumTarihi { get; set; }
        [Required(ErrorMessage = "Cinsiyet Se�iniz...")]
        public Nullable<bool> Cinsiyet { get; set; }
      
        [Display(Name = "Evlilik Durumu")]
        [Required(ErrorMessage = "Evlilik Durumu")]
        public Nullable<bool> EvliMi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADDRESS> ADDRESS { get; set; }
        public virtual Departman Departman { get; set; }
    }
}
