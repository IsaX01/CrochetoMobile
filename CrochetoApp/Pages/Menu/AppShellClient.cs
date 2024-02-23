using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrochetoApp.Pages.Menu
{
    public class AppShellClient : Shell
    {
        public AppShellClient()
        {
            // Agrega las páginas a las que quieres navegar
            Routing.RegisterRoute(nameof(Home.HomeClient), typeof(Home.HomeClient));
            // Agrega más páginas según sea necesario

            // Crea los elementos del menú
            var homeMenuItem = new FlyoutItem
            {
                Title = "Home",
                Icon = "home.png",
                Route = nameof(CrochetoApp.Pages.Home.HomeClient)
            };


            // Agrega los elementos del menú a Shell
            Items.Add(homeMenuItem);

            // Agrega más elementos de menú según sea necesario


        }
    }

}
