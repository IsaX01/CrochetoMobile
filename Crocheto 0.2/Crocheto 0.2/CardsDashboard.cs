using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Entry = Microcharts.ChartEntry;

namespace Crocheto_0._2
{
    public class CardsDashboard
    {
        public string Title { get; set; }
        public List<Entry> MonthlyData { get; set; }
    }

    public class DashboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CardsDashboard> _cards;
        public ObservableCollection<CardsDashboard> Cards
        {
            get { return _cards; }
            set
            {
                _cards = value;
                OnPropertyChanged(nameof(Cards));
            }
        }

        public DashboardViewModel()
        {
            Cards = new ObservableCollection<CardsDashboard>
        {
            new CardsDashboard
            {
                Title = "User Access",
                MonthlyData = new List<Entry>
                {
                    new Entry(200) { Label = "Enero", ValueLabel = "200", Color = SKColor.Parse("#266489") },
                    new Entry(250) { Label = "Febrero", ValueLabel = "250", Color = SKColor.Parse("#68B9C0") },
                    // ... más entradas para otros meses ...
                }
            },
            new CardsDashboard
            {
                Title = "Downloads",
                MonthlyData = new List<Entry>
                {
                    new Entry(300) { Label = "Enero", ValueLabel = "300", Color = SKColor.Parse("#90D585") },
                    new Entry(350) { Label = "Febrero", ValueLabel = "350", Color = SKColor.Parse("#F3C300") },
                    // ... más entradas para otros meses ...
                }
            },
            new CardsDashboard
            {
                Title = "Registered Users",
                MonthlyData = new List<Entry>
                {
                    new Entry(400) { Label = "Enero", ValueLabel = "400", Color = SKColor.Parse("#F37F64") },
                    new Entry(450) { Label = "Febrero", ValueLabel = "450", Color = SKColor.Parse("#42456E") },
                    // ... más entradas para otros meses ...
                }
            }
        };
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
