using System.ComponentModel.DataAnnotations;

namespace MusicalProject.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}