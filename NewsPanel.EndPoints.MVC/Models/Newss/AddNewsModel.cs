using System.Collections.Generic;

namespace NewsPanel.EndPoints.MVC.Models.Newss
{
    public class AddNewsModel : NewsModel
    {
        public List<int> SelectedCategory { get; set; }
        public List<int> SelectedKeyword { get; set; }
        public List<int> SelectedPlace { get; set; }
    }
}
