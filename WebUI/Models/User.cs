using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="İsim")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Adınız en az iki harf olmalı.")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name ="Soyisim")]
        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyadınız en az iki harf olmalı.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage ="Bu alanı boş bırakmayınız.")]
        [Display(Name ="Email")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-mail adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [Display(Name ="Şifre")]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Şifreniz en az 8 karakter olmalı; büyük-küçük harf, karakter ve rakam içermelidir.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [Display(Name ="Telefon")]
        [RegularExpression("[0-9]{3}[0-9]{3}[0-9]{4}", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [Display(Name ="Doğum Tarihi")]
        public string DateOfBirth { get; set; } = string.Empty;

        [Required(ErrorMessage = "Bu alanı boş bırakmayınız.")]
        [Display(Name = "Şehir")]
        public string City { get; set; } = string.Empty;

        [Required (ErrorMessage ="Bu alanı boş bırakmayınız.")]
        [Display(Name ="Cinsiyet")]
        public string Gender { get; set; } = string.Empty;
        
        [Url(ErrorMessage = "Lütfen geçerli bir URL giriniz.")]
        [Display(Name = "Web Sitesi")]
        public string Website { get; set; }

        [Display(Name = "Adres")]
        public string Adress { get; set; }
        [Display(Name = "Abonelik")]
        public bool IsSubscribed { get; set; }
        public byte[] Photo { get; set; }
    }
}