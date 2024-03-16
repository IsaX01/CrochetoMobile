using Crocheto_0._2.Services;
using System.Xml;

namespace Crocheto_0._2.Pages.Profile;

public partial class Profile : ContentPage
{
    public Profile()
    {
        InitializeComponent();
        GetUserData();
    }

    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Password();
    }

    private void Paid(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Payment();
    }

    private void Account(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Account();
    }

    private void Languages(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Languages();
    }

    private void Notification(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Notification();
    }

    private void Policy(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Policys();
    }
    public async void ShareApp(object sender, EventArgs e)
    {
        string fn = "Crocheto.txt";
        string file = Path.Combine(FileSystem.CacheDirectory, fn);
        File.WriteAllText(file, "Croheto App Link: https://CrochetoApp.com, Instagram: crochetoRD");
        await Share.Default.RequestAsync(new ShareFileRequest
        {
            Title = "Share text file",
            File = new ShareFile(file)
        });
    }


    public async Task GetUserData()
    {
        var authService = new AuthService();
        var user = await authService.GetUserProfile();

        if (user != null)
        {
            nameLabel.Text = user.Name;
            emailLabel.Text = user.Email;
            subscriptionLabel.Text = user.SubscriptionType;
        }
        else
        {
            _ = DisplayAlert("Error", "Could not load user profile", "OK");
            Application.Current.MainPage = new UserAppShell();
            return;
        }
    }
}