
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinRest.Models;

namespace XamarinRest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClient : ContentPage
	{
        RestClient restClient;
        public AddClient()
        {
            InitializeComponent();
            restClient = new RestClient();
        }
        async void Post_Client(object sender, System.EventArgs e)
        {
            Clientes newItem = new Clientes
            {
                nombre = clientes.Text,
                edad = edades.Text
            };
            await restClient.PostClient(newItem);
            await DisplayAlert("Mensaje", "Su cliente se agregó con éxito", "OK");
            await Navigation.PopAsync();
        }
       
    }
}