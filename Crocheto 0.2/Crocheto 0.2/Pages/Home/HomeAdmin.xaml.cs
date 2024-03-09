using Microcharts;
using SkiaSharp;

namespace Crocheto_0._2.Pages.Home;

public partial class HomeAdmin : ContentPage
{

    public HomeAdmin()
    {
        InitializeComponent();
        accessUsers.Chart = new BarChart
        {
            Entries = userEntries
        };
        downloads.Chart = new PointChart
        {
            Entries = downloadEntries
        };
        registerUsers.Chart = new DonutChart
        {
            Entries = registerEntries
        };

    }

    ChartEntry[] userEntries = new[]
    {
        new ChartEntry(200) { Label = "Enero", ValueLabel = "200", Color = SKColor.Parse("#266489") },
        new ChartEntry(250) { Label = "Febrero", ValueLabel = "250", Color = SKColor.Parse("#68B9C0") },
            new ChartEntry(300) { Label = "Marzo", ValueLabel = "300", Color = SKColor.Parse("#90D585") },
            new ChartEntry(350) { Label = "Abril", ValueLabel = "350", Color = SKColor.Parse("#F3C300") },
        new ChartEntry(400) { Label = "Mayo", ValueLabel = "400", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(450) { Label = "Junio", ValueLabel = "450", Color = SKColor.Parse("#42456E") },
        new ChartEntry(500) { Label = "Julio", ValueLabel = "500", Color = SKColor.Parse("#266489") },
        new ChartEntry(550) { Label = "Agosto", ValueLabel = "550", Color = SKColor.Parse("#68B9C0") },
        new ChartEntry(600) { Label = "Septiembre", ValueLabel = "600", Color = SKColor.Parse("#90D585") },
        new ChartEntry(650) { Label = "Octubre", ValueLabel = "650", Color = SKColor.Parse("#F3C300") },
        new ChartEntry(700) { Label = "Noviembre", ValueLabel = "700", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(750) { Label = "Diciembre", ValueLabel = "750", Color = SKColor.Parse("#42456E") },
    };

    ChartEntry[] downloadEntries = new[]
    {
        new ChartEntry(300) { Label = "Enero", ValueLabel = "300", Color = SKColor.Parse("#90D585") },
        new ChartEntry(350) { Label = "Febrero", ValueLabel = "350", Color = SKColor.Parse("#F3C300") },
        new ChartEntry(400) { Label = "Marzo", ValueLabel = "400", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(450) { Label = "Abril", ValueLabel = "450", Color = SKColor.Parse("#42456E") },
            new ChartEntry(500) { Label = "Mayo", ValueLabel = "500", Color = SKColor.Parse("#266489") },
        new ChartEntry(550) { Label = "Junio", ValueLabel = "550", Color = SKColor.Parse("#68B9C0") },
        new ChartEntry(600) { Label = "Julio", ValueLabel = "600", Color = SKColor.Parse("#90D585") },
        new ChartEntry(650) { Label = "Agosto", ValueLabel = "650", Color = SKColor.Parse("#F3C300") },
        new ChartEntry(700) { Label = "Septiembre", ValueLabel = "700", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(750) { Label = "Octubre", ValueLabel = "750", Color = SKColor.Parse("#42456E") },
        new ChartEntry(800) { Label = "Noviembre", ValueLabel = "800", Color = SKColor.Parse("#266489") },
        new ChartEntry(850) { Label = "Diciembre", ValueLabel = "850", Color = SKColor.Parse("#68B9C0") },
    };

    ChartEntry[] registerEntries = new[]
    {
        new ChartEntry(400) { Label = "Enero", ValueLabel = "400", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(450) { Label = "Febrero", ValueLabel = "450", Color = SKColor.Parse("#42456E") },
        new ChartEntry(500) { Label = "Marzo", ValueLabel = "500", Color = SKColor.Parse("#266489") },
        new ChartEntry(550) { Label = "Abril", ValueLabel = "550", Color = SKColor.Parse("#68B9C0") },
        new ChartEntry(600) { Label = "Mayo", ValueLabel = "600", Color = SKColor.Parse("#90D585") },
        new ChartEntry(650) { Label = "Junio", ValueLabel = "650", Color = SKColor.Parse("#F3C300") },
        new ChartEntry(700) { Label = "Julio", ValueLabel = "700", Color = SKColor.Parse("#F37F64") },
        new ChartEntry(750) { Label = "Agosto", ValueLabel = "750", Color = SKColor.Parse("#42456E") },
        new ChartEntry(800) { Label = "Septiembre", ValueLabel = "800", Color = SKColor.Parse("#266489") },
        new ChartEntry(850) { Label = "Octubre", ValueLabel = "850", Color = SKColor.Parse("#68B9C0") },
        new ChartEntry(900) { Label = "Noviembre", ValueLabel = "900", Color = SKColor.Parse("#90D585") },
        new ChartEntry(950) { Label = "Diciembre", ValueLabel = "950", Color = SKColor.Parse("#F3C300") },
    };
}