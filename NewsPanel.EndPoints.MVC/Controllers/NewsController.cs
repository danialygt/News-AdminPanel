using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.Contract.Categories;
using NewsPanel.Domain.Core.Contract.Keywords;
using NewsPanel.Domain.Core.Contract.Newss;
using NewsPanel.Domain.Core.Contract.Places;
using NewsPanel.Domain.Core.KeywordEntities;
using NewsPanel.Domain.Core.NewsEntity;
using NewsPanel.Domain.Core.PlaceEntities;
using NewsPanel.EndPoints.MVC.Models.Newss;
using NewsPanel.Infrastructure.DataAccess.Common;

namespace NewsPanel.EndPoints.MVC.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly IKeywordRepository _keywordRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsKeywordRepository _newsKeywordRepository;
        private readonly INewsPublishPlaceRepository _newsPublishPlaceRepository;
        private readonly INewsCategoryRepository _newsCategoryRepository;

        public NewsController(INewsRepository newsRepository,
            IKeywordRepository keywordRepository,
            IPlaceRepository placeRepository,
            ICategoryRepository categoryRepository,
            INewsKeywordRepository newsKeywordRepository,
            INewsPublishPlaceRepository newsPublishPlaceRepository,
            INewsCategoryRepository newsCategoryRepository
            )
        {
            _newsRepository = newsRepository;
            _keywordRepository = keywordRepository;
            _placeRepository = placeRepository;
            _categoryRepository = categoryRepository;
            _newsKeywordRepository = newsKeywordRepository;
            _newsPublishPlaceRepository = newsPublishPlaceRepository;
            _newsCategoryRepository = newsCategoryRepository;


        }

        public IActionResult List()
        {
            var news = _newsRepository.GetAll().ToList();
            var newsModelList = new List<NewsModel>();

            foreach (var item in news)
            {
                newsModelList.Add(new NewsModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    PublishDate = item.PublishDate,
                    KeywordForDisplay = GetKeywordFromNewsKeyword(item.Id),
                    CategoryForDisplay = GetCategoryFromNewsCategory(item.Id),
                    PlaceForDisplay = GetPlacesFromNewsPublishPlaces(item.Id)
                });
            }
            return View(newsModelList);
        }

        private List<Category> GetCategoryFromNewsCategory(int newsId)
        {
            var newsCategories = _newsCategoryRepository.GetAll().Where(c => c.NewsId == newsId).ToList();
            var newsCategory = new List<Category>();

            foreach (var item in newsCategories)
            {
                var cat = _categoryRepository.Get(item.CategoryId);
                if(cat != null)
                {
                    newsCategory.Add(cat);
                }
            }
            return newsCategory;
        }

        private List<Keyword> GetKeywordFromNewsKeyword(int newId)
        {
            var newsKeywords = _newsKeywordRepository.GetAll().Where(c => c.NewsId == newId).ToList();
            var newsKeyword = new List<Keyword>();

            foreach (var item in newsKeywords)
            {
                var keyW = _keywordRepository.Get(item.KeywordId);
                if (keyW != null)
                {
                    newsKeyword.Add(keyW);
                }
            }
            return newsKeyword;
        }

        private List<Place> GetPlacesFromNewsPublishPlaces(int newId)
        {
            var newsPublishPlaces = _newsPublishPlaceRepository.GetAll().Where(c => c.NewsId == newId).ToList();
            var newsPlace = new List<Place>();

            foreach (var item in newsPublishPlaces)
            {
                var keyW = _placeRepository.Get(item.PlaceId);
                if (keyW != null)
                {
                    newsPlace.Add(keyW);
                }
            }
            return newsPlace;
        }





        public IActionResult EditNews(int id)
        {
            var news = _newsRepository.Get(id);
            var newsModel = new AddNewsModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                PublishDate = news.PublishDate,
                SelectedCategory = new List<int>(),
                SelectedKeyword = new List<int>(),
                SelectedPlace = new List<int>(),
                KeywordForDisplay = _keywordRepository.GetAll().ToList(),
                CategoryForDisplay = _categoryRepository.GetAll().ToList(),
                PlaceForDisplay = _placeRepository.GetAll().ToList()
            };
            
            foreach (var item in GetCategoryFromNewsCategory(news.Id))
            {
                newsModel.SelectedCategory.Add(item.Id);
            }
            foreach (var item in GetKeywordFromNewsKeyword(news.Id))
            {
                newsModel.SelectedKeyword.Add(item.Id);
            }
            foreach (var item in GetPlacesFromNewsPublishPlaces(news.Id))
            {
                newsModel.SelectedPlace.Add(item.Id);
            }
            return View(newsModel);
        }

        //[HttpPut("News/EditNews/{id}")]
        [HttpPost]
        public IActionResult EditNews(AddNewsModel newsModel)
        {
            var entity = _newsRepository.Get(newsModel.Id);
            if (entity != null)
            {
                if (ModelState.IsValid)
                {
                    entity.Title = newsModel.Title;
                    entity.Content = newsModel.Content;
                    //entity.PublishDate = newsModel.PublishDate;

                    if (newsModel?.File?.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            newsModel.File.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                            entity.File = Convert.ToBase64String(fileBytes);
                        }
                    }

                    EditCategoryForNews(newsModel);
                    EditKeywordForNews(newsModel);
                    EditPlaceForNews(newsModel);

                    



                    _newsRepository.Save();
                    return RedirectToAction("List");
                }
            }
            else
            {
                ModelState.AddModelError("NewsNotExist", "This News Not Found!");
            }
            return View(newsModel);
        }

        private void EditCategoryForNews(AddNewsModel newsModel)
        {
            var selectedNewsCategory = _newsCategoryRepository.GetAll().Where(c => c.NewsId == newsModel.Id).ToList();
            foreach (var item in selectedNewsCategory)
            {
                _newsCategoryRepository.Delete(item);
            }
            if (newsModel.SelectedCategory != null)
            {
                foreach (var item in newsModel.SelectedCategory)
                {
                    _newsCategoryRepository.Add(new NewsCategory
                    {
                        NewsId = newsModel.Id,
                        CategoryId = item
                    });
                }
            }
        }

        private void EditKeywordForNews(AddNewsModel newsModel)
        {
            var selectedNewsKeyword = _newsKeywordRepository.GetAll().Where(c => c.NewsId == newsModel.Id).ToList();
            foreach (var item in selectedNewsKeyword)
            {
                _newsKeywordRepository.Delete(item);
            }
            if (newsModel.SelectedKeyword != null)
            {
                foreach (var item in newsModel.SelectedKeyword)
                {
                    _newsKeywordRepository.Add(new NewsKeyword
                    {
                        NewsId = newsModel.Id,
                        KeywordId = item
                    });
                }
            }
        }

        private void EditPlaceForNews(AddNewsModel newsModel)
        {
            var selectedNewsPlace = _newsPublishPlaceRepository.GetAll().Where(c => c.NewsId == newsModel.Id).ToList();
            foreach (var item in selectedNewsPlace)
            {
                _newsPublishPlaceRepository.Delete(item);
            }
            if (newsModel.SelectedPlace != null)
            {
                foreach (var item in newsModel.SelectedPlace)
                {
                    _newsPublishPlaceRepository.Add(new NewsPublishPlace
                    {
                        NewsId = newsModel.Id,
                        PlaceId = item
                    });
                }
            }
        }



        public IActionResult DeleteNews(int id)
        {
            var news = _newsRepository.Get(id);
            var newsModel = new AddNewsModel()
            {
                Id = news.Id,
                Title = news.Title,
                Content = news.Content,
                PublishDate = news.PublishDate,
                KeywordForDisplay = GetKeywordFromNewsKeyword(news.Id),
                CategoryForDisplay = GetCategoryFromNewsCategory(news.Id),
                PlaceForDisplay = GetPlacesFromNewsPublishPlaces(news.Id)
            };
            return View(newsModel);
        }
        //[HttpDelete("News/DeleteNews/{id}")]
        [HttpPost]
        public IActionResult DeleteNews(int id, AddNewsModel news)
        {
            var entity = _newsRepository.Get(news.Id);
            if (entity != null)
            {
                
                _newsRepository.Delete(entity);
                return RedirectToAction("List");
                
            }
            else
            {
                ModelState.AddModelError("NewsNotExist", "This News Not Found!");
            }
            return View(news);
        }


        public IActionResult AddNews()
        {
            var model = new AddNewsModel()
            {
                KeywordForDisplay = _keywordRepository.GetAll().ToList(),
                PlaceForDisplay = _placeRepository.GetAll().ToList(),
                CategoryForDisplay = _categoryRepository.GetAll().ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddNews(AddNewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                var model = new News()
                {
                    Title = newsModel.Title,
                    Content = newsModel.Content,
                    PublishDate = newsModel.PublishDate
                };

                if (newsModel?.File?.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        newsModel.File.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        model.File = Convert.ToBase64String(fileBytes);
                    }
                }

                var newNews = _newsRepository.Add(model);
                
                if (newsModel.SelectedCategory != null)
                {
                    foreach (var item in newsModel.SelectedCategory)
                    {
                        _newsCategoryRepository.Add(new NewsCategory
                        {
                            NewsId = newNews.Id,
                            CategoryId = item
                        });
                    }
                }
                if (newsModel.SelectedKeyword != null)
                {
                    foreach (var item in newsModel.SelectedKeyword)
                    {
                        _newsKeywordRepository.Add(new NewsKeyword
                        {
                            NewsId = newNews.Id,
                            KeywordId = item
                        });
                    }
                }
                if (newsModel.SelectedPlace != null)
                {
                    foreach (var item in newsModel.SelectedPlace)
                    {
                        _newsPublishPlaceRepository.Add(new NewsPublishPlace
                        {
                            NewsId = newNews.Id,
                            PlaceId = item
                        });
                    }
                }

                return RedirectToAction("List");
            }
            return View(newsModel);
        }

    }
}
