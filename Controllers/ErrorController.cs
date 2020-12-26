using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IS4439_CA2.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int StatusCode)
        {
          if(StatusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }
    }
}
