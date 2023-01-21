using dotnet.Controllers.Data;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        public ObjectResult NewPayment(NewPaymentInput Input)
        {
           if (Input.CardNumber == 0)
            {
                return new BadRequestObjectResult("Invalid Card");
            }

            return new OkObjectResult("Paid");
        }

    }
}

