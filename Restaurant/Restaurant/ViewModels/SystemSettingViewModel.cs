using Microsoft.AspNetCore.Http;
using RESTAURANT.Models;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewModels
{
    public class SystemSettingViewModel : BaseEntity
    {
        public int SystemSettingId { get; set; }
        [Required]
        [Display(Name = "logo1")]
        public string SystemSettingLogoImageUrl { get; set; }
        [Display(Name = "logo2")]
        public string SystemSettingLogoImageUrl2 { get; set; }
        [Display(Name = "Copyright")]
        public string SystemSettingCopyright { get; set; }
        [Display(Name = "NoteTitle")]
        public string SystemSettingWelcomeNoteTitle { get; set; }
        [Display(Name = "NoteBreef")]


        public string SystemSettingWelcomeNoteBreef { get; set; }
        [Display(Name = "NoteDesc")]

        public string SystemSettingWelcomeNoteDesc { get; set; }
        [Display(Name = "NoteUrl")]

        public string SystemSettingWelcomeNoteUrl { get; set; }
        [Display(Name = "NoteImage")]

        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        [Display(Name = "Location")]

        public string SystemSettingMapLocation { get; set; }


        public IFormFile LogoImage { get; set; }
        public IFormFile LogoImage2 { get; set; }
        public IFormFile NoteImage { get; set; }
    }
}
