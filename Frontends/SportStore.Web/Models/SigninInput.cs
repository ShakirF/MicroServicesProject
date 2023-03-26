using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models;

public class SigninInput
{
    [Display(Name = "Email adresiniz")]
    public string Email { get; set; } = null!;

    [Display(Name = "Shifreniz")]
    public string Password { get; set; } = null!;

    [Display(Name = "Meni xatirla")]
    public bool IsRemember { get; set; }
}

