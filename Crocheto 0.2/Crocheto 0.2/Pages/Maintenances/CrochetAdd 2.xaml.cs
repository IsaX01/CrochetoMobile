using Crocheto_0._2.DTO;
using Crocheto_0._2.Pages.Home;
using Crocheto_0._2.Services;

namespace Crocheto_0._2.Pages.Maintenances;

public partial class CrochetAdd2 : ContentPage
{
    private CrochetService _crochetService;

    private byte[] _selectedImage;
    private byte[] _selectedPdf;

    public CrochetAdd2()
    {
        _crochetService = new CrochetService();
        InitializeComponent();
    }
    private async void HomeAdmin(object sender, EventArgs e)
    {
        var appShell = new AdminAppShell();
        await appShell.GoToAsync("//homemaintenance");
        Application.Current.MainPage = appShell;
    }

    private async void SelectImage(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Select a Image"
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            _selectedImage = new byte[stream.Length];
            await stream.ReadAsync(_selectedImage, 0, _selectedImage.Length);
            stream.Close();
        }
    }

    private async void SelectPdf(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Pdf,
            PickerTitle = "Select a PDF File"
        });

        if (result != null)
        {
            var stream = await result.OpenReadAsync();
            _selectedPdf = new byte[stream.Length];
            await stream.ReadAsync(_selectedPdf, 0, _selectedPdf.Length);
            stream.Close();
        }
    }

    private async void SaveCrochet(object sender, EventArgs e)
    {
        var userId = await SecureStorage.GetAsync("UserId");
        var IsAdmin = await SecureStorage.GetAsync("IsAdmin");

        var crochet = new ViewsModels.CrochetNewViewModel
        {
            Title = titleEntry.Text,
            Description = descriptionEditor.Text,
            Subtitle = subtitleEntry.Text,
            StatusText = statusTextEntry.Text,
            Image = Convert.ToBase64String(_selectedImage),
            PdfFile = _selectedPdf,
            UserId = userId,
            IsAdmin = bool.Parse(IsAdmin)
        };



        try
        {
            var savedCrochet = await _crochetService.Create(crochet);
            await DisplayAlert("Success", "The crochet is save correctly", "OK");

            titleEntry.Text = string.Empty;
            descriptionEditor.Text = string.Empty;
            subtitleEntry.Text = string.Empty;
            statusTextEntry.Text = string.Empty;
            _selectedImage = null;
            _selectedPdf = null;

        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Unexpected error saving crochet: " + ex.Message, "OK");
        }
    }

}