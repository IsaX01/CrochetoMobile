using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrochetoApp
{ 
    public class CardData
        {
            public string Image { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Subtitle { get; set; }
            public string Trending { get; set; }
        }
    class CardsHome
    {
        public ObservableCollection<CardData> TestCard1 { get; set; }
        public ObservableCollection<CardData> TestCard2 { get; set; }

        public CardsHome()
        {
            TestCard1 = new ObservableCollection<CardData>
        {
            new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
            new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
             new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
              new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
               new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
                new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
            // Agrega más elementos según sea necesario
        };

            TestCard2 = new ObservableCollection<CardData>
        {
            new CardData { Image = "", Title = "Title 2", Description = "", Subtitle = "Premium", Trending = "Hot" },
            // Agrega más elementos según sea necesario
        };
        }
    }
  
}
