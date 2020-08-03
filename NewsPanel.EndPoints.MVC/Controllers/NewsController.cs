using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class NewsController : Controller
    {
        
        public IActionResult List()
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
