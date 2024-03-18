
using Crocheto_0._2.DTO;
using Crocheto_0._2.ViewsModels;

namespace Crocheto_0._2.Pages.Home;

public partial class CrochetDetail : ContentPage
{
    private CrochetViewModel _BindingContext;

    public CrochetDetail(CrochetDTO crochet)
	{
		InitializeComponent();
        BindingContext = crochet;
    }

    void OnDownloadClicked(object sender, EventArgs e)
    {
        _BindingContext = new CrochetViewModel();

        var button = (ImageButton)sender;
        try
        {
            var crochet = button.CommandParameter as CrochetDTO;
            var viewModel = (CrochetViewModel)_BindingContext;
            viewModel.Download(crochet);
        }
        catch (InvalidCastException)
        {
            DisplayAlert("Error:", "Crochet can't be downloaded", "OK");
            return;
        }
    }

    void OnShareClicked(object sender, EventArgs e)
    {
        _BindingContext = new CrochetViewModel();
        var button = (ImageButton)sender;
        try
        {
            var crochet = button.CommandParameter as CrochetDTO;
            var viewModel = (CrochetViewModel)_BindingContext;
            viewModel.ShareCard(crochet);
        }
        catch (InvalidCastException)
        {
            DisplayAlert("Error:", "Crochet can't be shared", "OK");
            return;
        }
    }

    private void HomeClient(object sender, EventArgs e)
    {
        Application.Current.MainPage = new UserAppShell();
    }
}