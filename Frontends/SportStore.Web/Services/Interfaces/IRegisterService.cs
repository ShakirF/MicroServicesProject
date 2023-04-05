using SportStore.Web.Models;

namespace SportStore.Web.Services.Interfaces;

public interface IRegisterService
{
	Task<bool> SignUp(SignUpInput signUpInput);
}

