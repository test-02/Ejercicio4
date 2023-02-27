using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio4.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEmpledos : ContentPage
    {
        public ListEmpledos()
        {
            InitializeComponent();
        }

        private async void Lista_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            String sexResult = await DisplayActionSheet("Escoja una opcion", "Cancelar", null, "Ver Registro");


            switch (sexResult)
            {
                case "Ver Registro":
                    Models.Empleado item = (Models.Empleado)e.Item;

                    var newpage = new VerRegistro();
                    newpage.BindingContext = item;

                    await Navigation.PushAsync(newpage);
                    break;

                default:
                    break;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Lista.ItemsSource = await App.BaseDatos.listaempleados();
        }
    }
}