using Microsoft.AspNetCore.Mvc;
using SportStore.Shared.Dtos;

namespace SportStore.Shared.ControllerBases;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(Response<T> response)
    {
        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }
}

