using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
    class CardsHome : INotifyPropertyChanged
    {

        public ObservableCollection<CardData> AllCards { get; private set; }
        public ObservableCollection<CardData> RecentsCollection { get; private set; }
        public ObservableCollection<CardData> TrendingCollection { get; private set; }
        public  ObservableCollection<CardData> FilteredCollection { get; set; }

        private Style recentButtonStyle;
        public Style RecentButtonStyle
        {
            get { return recentButtonStyle; }
            set
            {
                if (recentButtonStyle != value)
                {
                    recentButtonStyle = value;
                    OnPropertyChanged(nameof(RecentButtonStyle));
                }
            }
        }

        private Style trendingButtonStyle;
        public Style TrendingButtonStyle
        {
            get { return trendingButtonStyle; }
            set
            {
                if (trendingButtonStyle != value)
                {
                    trendingButtonStyle = value;
                    OnPropertyChanged(nameof(TrendingButtonStyle));
                }
            }
        }

        // Add other collections for more categories

        public ICommand FilterCommand { get; }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CardsHome()
        {
            FilterCommand = new Command<string>(category =>
            {
                // Reset all button styles to inactive
                RecentButtonStyle = (Style)Application.Current.Resources["ActiveButtonStyle"];
                TrendingButtonStyle = (Style)Application.Current.Resources["InactiveButtonStyle"];
                // And so on for each button

                // Then, based on the category, set the active button style
                switch (category)
                {
                    case "Recents":
                        RecentButtonStyle = (Style)Application.Current.Resources["ActiveButtonStyle"];
                        break;
                    case "Trending":
                        TrendingButtonStyle = (Style)Application.Current.Resources["ActiveButtonStyle"];
                        break;
                        // And so on for each category
                }
            });

            FilterCommand = new Command(FilterCards);
            AllCards = new ObservableCollection<CardData>();

            RecentsCollection = new ObservableCollection<CardData>
            {
            new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
            new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
             new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
              new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
               new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
                new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
                new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
            new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
             new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
              new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
               new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },
                new CardData { Image = "pdf.jpg", Title = "Title 1", Description = "Description 1", Subtitle = "Free", Trending = "Trending" },

             };

            TrendingCollection = new ObservableCollection<CardData>
            {
                new CardData { Image = "", Title = "Title 2", Description = "", Subtitle = "Premium", Trending = "Hot" },
           
            };

            FilteredCollection = RecentsCollection; // Initial state

        }



        private void FilterCards(object parameter)
            {
            string filter = (string)parameter;

            // Filter based on parameter
            switch (filter)
            {
                case "Recents":
                    FilteredCollection = RecentsCollection;
                    break;
                case "Trending":
                    FilteredCollection = TrendingCollection;
                    break;
                case "Favorites":
                    // Implement logic to filter favorites
                    break;
                case "Premium":
                    // Implement logic to filter premium cards
                    break;
                case "Free":
                    // Implement logic to filter free cards
                    break;
                default:
                    // Handle invalid filter or errors
                    break;
            }

            OnPropertyChanged("FilteredCollection");
        }
       
    }


   


}
