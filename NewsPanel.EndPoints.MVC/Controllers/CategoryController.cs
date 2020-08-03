using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.Contract.Categories;

namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            var categories = _categoryRepository.GetAll().ToList();
            return View(categories);
        }




        public IActionResult EditCategory(int  id)
        {
            var category = _categoryRepository.Get(id);
            return View(category);
        }

        //[HttpPut("Category/EditCategory/{id}")]
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            var entity = _categoryRepository.Get(category.Id);
            if (entity != null)
            {
                entity.Title = category.Title;
                _categoryRepository.Save();
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("CategotyNotExist", "This Category Not Found!");
                return View(category);
            }
        }






        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.Get(id);
            return View(category);
        }

        //[HttpDelete("Category/DeleteCategory/{id}")]
        [HttpPost]
        public IActionResult DeleteCategory(int id, Category category)
        {
            var entity = _categoryRepository.Get(category.Id);
            if (entity != null)
            {
                _categoryRepository.Delete(entity);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("CategotyNotExist", "This Category Not Found!");
                return View(category);
            }
        }




        public IActionResult AddCategory()
        {
            return View(new Category());
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            var categories = _categoryRepository.GetAll();
            foreach (var item in categories)
            {
                if (item.Title == category.Title)
                {
                    ModelState.AddModelError("CategoryExist", "Already this category is exist.");
                    break;
                }
            }
           
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(new Category() { Title = category.Title });
                return RedirectToAction("List");
            }
            
            return View(category);
            
        }



    }
}
