using Ejercicio4.Controllers;
using Ejercicio4.Models;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio4
{
    public partial class App : Application
    {

        static EmpleadoBD basedatos;

        public static EmpleadoBD BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new EmpleadoBD(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EmpleadoBD.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
