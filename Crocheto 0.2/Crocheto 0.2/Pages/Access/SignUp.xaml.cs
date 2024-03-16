using Crocheto_0._2.Services;
using Crocheto_0._2.ViewsModels;
using System.Diagnostics;

namespace Crocheto_0._2.Pages.Access;

public partial class SignUp : ContentPage
{
    public RegisterViewModel RegisterViewModel { get; set; }
    public SignUp()
    {
        InitializeComponent();
        BindingContext = new RegisterViewModel();
    }

    private void LoginClick(object sender, EventArgs e)
    {
        Application.Current.MainPage = new Login();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        var registerViewModel = BindingContext as RegisterViewModel;

        if (registerViewModel == null || string.IsNullOrEmpty(registerViewModel.Name) || string.IsNullOrEmpty(registerViewModel.Email) || string.IsNullOrEmpty(registerViewModel.Password))
        {
            _ = DisplayAlert("Error", "All fields must be filled", "OK");
            return;
        }

        registerViewModel.IsLoading = true;
        Debug.WriteLine($"Name: {registerViewModel.Name}, Email: {registerViewModel.Email}, Password: {registerViewModel.Password}");

        var authService = new AuthService();
        if (authService == null)
        {
            Debug.WriteLine("authService is null");
            return;
        }

        var userDTO = await authService.Register(registerViewModel);
        if (userDTO == null)
        {
            registerViewModel.IsLoading = false;
            _ = DisplayAlert("Error", "Registration failed", "OK");
            return;
        }

        Debug.WriteLine($"UserDTO: {userDTO.Rol}, {userDTO.Id}, {userDTO.Token}");

        if (userDTO != null)
        {
            _ = DisplayAlert("Success", "User created successfully", "OK");
            Application.Current.MainPage = new Login();
        }
        else
        {
            _ = DisplayAlert("Error", "Registration failed", "OK");
        }
        registerViewModel.IsLoading = false;
    }

}