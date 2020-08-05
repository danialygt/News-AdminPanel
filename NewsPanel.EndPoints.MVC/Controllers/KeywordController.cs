using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPanel.Domain.Core.Contract.Keywords;
using NewsPanel.Domain.Core.KeywordEntities;

namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class KeywordController : Controller
    {
        private readonly IKeywordRepository _keywordRepository;

        public KeywordController(IKeywordRepository keywordRepository)
        {
            _keywordRepository = keywordRepository;
        }

        public IActionResult List()
        {
            var keywords = _keywordRepository.GetAll().ToList();
            return View(keywords);
        }




        public IActionResult EditKeyword(int id)
        {
            var keyword = _keywordRepository.Get(id);
            return View(keyword);
        }

        //[HttpPut("Keyword/EditKeyword/{id}")]
        [HttpPost]
        public IActionResult EditKeyword(Keyword keyword)
        {
            var entity = _keywordRepository.Get(keyword);
            if (entity != null)
            {
                entity.Title = keyword.Title;
                _keywordRepository.Save();
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("KeywordNotExist", "This Keyword Not Found!");
                return View(keyword);
            }
        }






        public IActionResult DeleteKeyword(int id)
        {
            var keyword = _keywordRepository.Get(id);
            return View(keyword);
        }

        //[HttpDelete("Keyword/DeleteKeyword/{id}")]
        [HttpPost]
        public IActionResult DeleteKeyword(int id, Keyword keyword)
        {
            var entity = _keywordRepository.Get(keyword);
            if (entity != null)
            {
                _keywordRepository.Delete(entity);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("KeywordNotExist", "This Keyword Not Found!");
                return View(keyword);
            }
        }




        public IActionResult AddKeyword()
        {
            return View(new Keyword());
        }

        [HttpPost]
        public IActionResult AddKeyword(Keyword keyword)
        {
            var keywords = _keywordRepository.GetAll();
            foreach (var item in keywords)
            {
                if (item.Title == keyword.Title)
                {
                    ModelState.AddModelError("KeywordExist", "Already this Keyword is exist.");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _keywordRepository.Add(new Keyword() { Title = keyword.Title });
                return RedirectToAction("List");
            }

            return View(keyword);

        }



    }
}
