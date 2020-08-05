using NewsPanel.Domain.Core.CategoryEntities;
using NewsPanel.Domain.Core.KeywordEntities;
using NewsPanel.Domain.Core.PlaceEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace NewsPanel.EndPoints.MVC.Models.Newss
{
    public class NewsModel
    {
        public int Id { get; set; }
        [Display(Name ="Date")]
        public DateTime PublishDate { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string Title { get; set; }
        [Required] 
        public string Content { get; set; }
        public IFormFile File { get; set; }

        [Display(Name = "Categories")]
        public List<Category> CategoryForDisplay { get; internal set; }
        [Display(Name = "Keywords")]
        public List<Keyword> KeywordForDisplay { get; internal set; }
        [Display(Name = "Places")]
        public List<Place> PlaceForDisplay { get; internal set; }
    }
}
