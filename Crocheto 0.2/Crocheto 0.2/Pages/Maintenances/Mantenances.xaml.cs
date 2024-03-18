using Crocheto_0._2.Services;

namespace Crocheto_0._2.Pages.Maintenances;

public partial class Mantenances : ContentPage
{
    public Mantenances()
    {
        InitializeComponent();
        GetUserData();
    }

    public async Task GetUserData()
    {
        var authService = new AuthService();
        var user = await authService.GetUserProfile();

        if (user != null)
        {
            nameLabel.Text = user.Name;
            emailLabel.Text = user.Email;
            RolLabel.Text = user.Rol;
        }
        else
        {
            _ = DisplayAlert("Error", "Could not load user profile", "OK");
            Application.Current.MainPage = new UserAppShell();
            return;
        }
    }

    private void AllCrochets(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Crochets();
    }

    private void AddCrochet(object sender, EventArgs e)
    {
        Application.Current.MainPage = new CrochetAdd2();
    }
    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Password();
    }

    private void Paid(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Payment();
    }

    private void Account(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Account2();
    }

    private void Languages(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Languages();
    }

    private void Notification(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Notification();
    }

    private void Policy(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Policys();
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
}