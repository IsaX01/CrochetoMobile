using Crocheto_0._2.DTO;
using Crocheto_0._2.Pages.Maintenances;
using Crocheto_0._2.Services;
using Crocheto_0._2.ViewsModels;
using System.Diagnostics;
using System.Globalization;

namespace Crocheto_0._2.Pages.Home;

public partial class HomeClient : ContentPage
{
    public HomeClient()
    {
        InitializeComponent();
        BindingContext = new CrochetViewModel();

        MessagingCenter.Subscribe<CrochetViewModel, string>(this, "Error", async (sender, arg) =>
        {
            await DisplayAlert("Error", arg, "OK");
        });
    }

    void OnDownloadClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var crochet = (CrochetDTO)button.CommandParameter;
        var viewModel = (CrochetViewModel)BindingContext;
        viewModel.Download(crochet);
    }

    void OnShareClicked(object sender, EventArgs e)
    {
        var button = (ImageButton)sender;
        var crochet = (CrochetDTO)button.CommandParameter;
        var viewModel = (CrochetViewModel)BindingContext;
        viewModel.ShareCard(crochet);
    }

    void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        ((CrochetViewModel)BindingContext).LoadData();
    }

    private void AddCrochet(object sender, EventArgs e)
    {
        Application.Current.MainPage = new CrochetAdd();
    }

    private async void OnCardTapped(object sender, EventArgs e)
    {
        Debug.WriteLine("Sender type:", sender.GetType());
        var frame = sender as Frame;
        if (frame != null)
        {
            var item = frame.BindingContext as CrochetDTO;

            Debug.WriteLine("Item to load:", item);

            if (item != null)
            {
                var animation = new Animation(v => frame.Scale = v, 1, 1.1);
                animation.Add(0.5, 1, new Animation(v => frame.Scale = v, 1.1, 1));
                frame.Animate("ScaleTo", animation, 16, 250, Easing.Linear, (v, c) => frame.Scale = 1);
                await Navigation.PushAsync(new CrochetDetail(item));
            }
            else
            {
                await DisplayAlert("Error:", "Crochet can't load correctly", "OK");
                return;
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        MessagingCenter.Unsubscribe<CrochetViewModel, string>(this, "Error");
    }


}