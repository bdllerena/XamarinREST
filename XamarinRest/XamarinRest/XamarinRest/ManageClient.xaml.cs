using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.Models;

namespace XamarinRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManageClient : ContentPage
	{
        RestClient restClient;
        public ManageClient ()
		{
			InitializeComponent ();
            restClient = new RestClient();
        }
        async void Update_Client(object sender, System.EventArgs e)
        {
            Clientes updateItem = new Clientes
            {
                nombre = clientes.Text,
                edad = edades.Text
            };
            await restClient.PutClient(id.Text, updateItem);
            await DisplayAlert("Mensaje", "Su cliente se actualizo con éxito", "OK");
            await Navigation.PopAsync();
        }
        async void Delete_Client(object sender, EventArgs e)
        {
            try
            {
                await DisplayAlert("Mensaje", "Su cliente se elimino con éxito", "OK");
                await restClient.DeleteClient(id.Text);

            }
            catch (System.Exception exception)
            {

                await DisplayAlert("Mensaje", exception.ToString(), "OK");
                System.Diagnostics.Debug.WriteLine(exception);
            }
            await Navigation.PopAsync();
        }
    }
}