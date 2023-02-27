using Ejercicio4.Models;
using Ejercicio4.Views;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace Ejercicio4
{
    public partial class MainPage : ContentPage
    {
        String pathImagen = "";
        byte[] imageToSave;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void PinkImage_Clicked(object sender, EventArgs e)
        {   
            // Esta es la manera mas sencilla
            /*var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = "photo.jpg"
            });
            pathImagen = takepic.Path;


            if (takepic != null)
            {
                pinkImage.Source = ImageSource.FromStream(() => {
                    return takepic.GetStream();
                });
            }*/

            // Esta lleva un poco mas de trabajo ya que la imagen se convierte en un arreglo bytes como lo enseño el ingeniero
            var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = DateTime.Now.ToString() + "_photo.jpg",
                SaveToAlbum = true
            });
            pathImagen = takepic.Path;

            if (takepic != null)
            {
                imageToSave = null;
                MemoryStream memoryStream = new MemoryStream();

                takepic.GetStream().CopyTo(memoryStream);
                imageToSave = memoryStream.ToArray();

                pinkImage.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });
            }
        }

        private async void Guardar_Clicked(object sender, EventArgs e)
        {
            if (pathImagen == "")
            {
                await DisplayAlert("Aviso", "Datos de Imagen faltante (Recuerde dar permisos de almacenamiento)", "Ingrese los datos");

            } 
            else if (String.IsNullOrEmpty(txtNombre.Text))
            {
                await DisplayAlert("Aviso", "Dato Nombre faltante", "Ingrese los datos");

            } 
            else if (String.IsNullOrEmpty(txtDes.Text))
            {
                await DisplayAlert("Aviso", "Dato Descripcion faltante", "Ingrese los datos");
            }
            else
            {
                var empleado = new Empleado
                {
                    nombre = txtNombre.Text,
                    descripcion = txtDes.Text,
                    image = imageToSave
                };

                var resultado = await App.BaseDatos.EmpleadoGuardar(empleado);
                if (resultado != 0)
                {
                    await DisplayAlert("Aviso", "Datos guardados con exito", "OK");
                    pinkImage.Source = ("");
                    pathImagen = "";
                    txtNombre.Text = "";
                    txtDes.Text = "";
                }
                else
                {
                    await DisplayAlert("Error", "Debe habilitar el almacenamiento", "OK");
                }
            }
        }

        private async void Lista_Clicked(object sender, EventArgs e)
        {
            var newpage = new ListEmpledos();
            await Navigation.PushAsync(newpage);
        }
    }
}
