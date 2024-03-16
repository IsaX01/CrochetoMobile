using Crocheto_0._2.DTO;
using Crocheto_0._2.Pages.Maintenances;
using Crocheto_0._2.Services;
using Crocheto_0._2.ViewsModels;

namespace Crocheto_0._2.Pages.Home;

public partial class HomeClient : ContentPage
{

    public HomeClient()
    {
        InitializeComponent();
        BindingContext = new CrochetViewModel();

    }

    private void AddCrochet(object sender, EventArgs e)
    {
        Application.Current.MainPage = new CrochetAdd();
    }


}