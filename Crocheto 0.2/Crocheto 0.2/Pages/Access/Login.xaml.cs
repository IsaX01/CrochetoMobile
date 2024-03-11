using Crocheto_0._2.Services;
using Crocheto_0._2.ViewsModels;
using System.Diagnostics;

namespace Crocheto_0._2.Pages.Access;

public partial class Login : ContentPage
{ 
    public LoginViewModel LoginViewModel { get; set; }
    public Login()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
        Debug.WriteLine("hOla carAMBola12");
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        Debug.WriteLine("hOla carAMBola perra", LoginViewModel);
        var authService = new AuthService();
        var userDTO = await authService.Login(LoginViewModel);

        Console.WriteLine("MMguebo", userDTO);

        if (userDTO != null)
        {
            // Almacenar token y rol (ej. SecureStorage)
            // Navegar a la página principal según el rol

            // Ejemplo: Navegar a página principal para administradores
            if (userDTO.Rol == "Admin")
            {
                Application.Current.MainPage = new AdminAppShell();
            }
            // Ejemplo: Navegar a página principal para usuarios
            else
            {
                Application.Current.MainPage = new UserAppShell();
            }
        }
        else
        {
            _ = DisplayAlert("Error", "Invalid credentials", "OK");
        }
    }

    private void SignUpClick(object sender, EventArgs e)
    {
        Application.Current.MainPage = new SignUp();
    }

    private void NewPassword(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Profile.Password2();
    }

}