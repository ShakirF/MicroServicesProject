using System.ComponentModel.DataAnnotations;

namespace SportStore.Web.Models;

public class SigninInput
{
	[Required]
	[Display(Name = "Email Address")]
	public string Email { get; set; } = null!;

	[Required]
	[Display(Name = "Password")]
	public string Password { get; set; } = null!;

	[Required]
	[Display(Name = "Remember me")]
	public bool IsRemember { get; set; }
}

