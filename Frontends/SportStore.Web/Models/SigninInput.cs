using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models;

public class SigninInput
{
    [Required]
    [Display(Name = "Email adresiniz")]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Şifrəniz")]
    public string Password { get; set; } = null!;

    [Required]
    [Display(Name = "Məni xatırla")]
    public bool IsRemember { get; set; }
}

