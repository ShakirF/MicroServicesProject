using Microsoft.AspNetCore.Mvc;
using SportStore.Shared.ControllerBases;
using SportStore.Shared.Dtos;

namespace SportStore.Services.FakePayment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FakePaymentsController : CustomBaseController
{
    [HttpPost]
    public IActionResult ReceivePaymnet()
    {
        return CreateActionResultInstance(Response<NoContent>.Success(200));
    }
}

