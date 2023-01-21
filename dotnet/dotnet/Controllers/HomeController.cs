using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Repositories;
using dotnet.Domain;
using Microsoft.AspNetCore.Mvc;
using dotnet.Helpers;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Home()
        {
            var Response = new
            {
                Name = "DotNet Barros",
                Version = "1.0.0"
           };

            return new JsonResult(Response);
        }

    }
}

