
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPanel.Domain.Core.Contract.Places;
using NewsPanel.Domain.Core.PlaceEntities;


namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class PlaceController : Controller
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public IActionResult List()
        {
            var places = _placeRepository.GetAll().ToList();
            return View(places);
        }




        public IActionResult EditPlace(int id)
        {
            var place = _placeRepository.Get(id);
            return View(place);
        }

        //[HttpPut("Place/EditPlace/{id}")]
        [HttpPost]
        public IActionResult EditPlace(Place place)
        {
            var entity = _placeRepository.Get(place);
            if (entity != null)
            {
                entity.Name = place.Name;
                _placeRepository.Save();
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("PlaceNotExist", "This Place Not Found!");
                return View(place);
            }
        }






        public IActionResult DeletePlace(int id)
        {
            var place = _placeRepository.Get(id);
            return View(place);
        }

        //[HttpDelete("Place/DeletePlace/{id}")]
        [HttpPost]
        public IActionResult DeletePlace(int id, Place place)
        {
            var entity = _placeRepository.Get(place);
            if (entity != null)
            {
                _placeRepository.Delete(entity);
                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("PlaceNotExist", "This Place Not Found!");
                return View(place);
            }
        }




        public IActionResult AddPlace()
        {
            return View(new Place());
        }

        [HttpPost]
        public IActionResult AddPlace(Place place)
        {
            var places = _placeRepository.GetAll();
            foreach (var item in places)
            {
                if (item.Name == place.Name)
                {
                    ModelState.AddModelError("PlaceExist", "Already this Place is exist.");
                    break;
                }
            }

            if (ModelState.IsValid)
            {
                _placeRepository.Add(new Place() { Name = place.Name });
                return RedirectToAction("List");
            }

            return View(place);

        }


    }
}
