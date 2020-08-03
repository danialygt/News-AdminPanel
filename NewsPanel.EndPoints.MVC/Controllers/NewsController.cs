using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class NewsController : Controller
    {
        
        public IActionResult NewsList()
        {
            return View();
        }


        //public IActionResult AddNews()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddNews()
        //{
        //    return View();
        //}
        //public IActionResult DeleteNews()
        //{
        //    return View();
        //}
        //[HttpDelete]
        //public IActionResult DeleteNews()
        //{
        //    return View();
        //}
        //public IActionResult EditNews()
        //{
        //    return View();
        //}
        //[HttpPut]
        //public IActionResult EditNews()
        //{
        //    return View();
        //}

    }
}
