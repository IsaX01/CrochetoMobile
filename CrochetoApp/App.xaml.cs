namespace CrochetoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Pages.Access.Login();
        }
    }
}
