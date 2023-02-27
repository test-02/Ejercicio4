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
    public partial class VerRegistro : ContentPage
    {
        public VerRegistro()
        {
            InitializeComponent();
        }

        private async void Lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}