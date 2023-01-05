using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FibonacciController : ControllerBase
    {
        [HttpGet(Name = "Fibonacci")]
        public List<int> Get()
        {
            List<int> list = new List<int>();

            int num = 0;
            for(int i = 0; i<100; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    list.Add(num);
                    num++;
                }
            }

            return list;
        }
    }
}

