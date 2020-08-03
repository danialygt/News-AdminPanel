using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class KeywordController : Controller
    {

        public IActionResult List()
        {
            return View();
        }
    }
}
