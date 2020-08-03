using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPanel.Domain.Core.PlaceEntities
{
    public class NewsPublishPlace:BaseEntity
    {
        public int NewsId { get; set; }
        public int PlaceId { get; set; }
    }
}
