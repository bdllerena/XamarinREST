using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinRest.Models;

namespace XamarinRest
{
    public partial class MainPage : ContentPage
    {
#pragma warning disable CS0649 // El campo 'MainPage.restClient' nunca se asigna y siempre tendrá el valor predeterminado null
        private RestClient restClient;
#pragma warning restore CS0649 // El campo 'MainPage.restClient' nunca se asigna y siempre tendrá el valor predeterminado null
        List<Clientes> items;
        public MainPage()
        {
            InitializeComponent();
            restClient = new RestClient();
            RefreshData();
            var minutes = TimeSpan.FromSeconds(5);

            Device.StartTimer(minutes, () => {

                RefreshData();
                return true;
            });


        }
        async void RefreshData()
        {
            items = await restClient.GetClient();
            listClient.ItemsSource = items.OrderBy(item => item.id).ThenBy(item => item.nombre).ThenBy(item => item.edad).ToList();
        }
        async void Add_Client(object sender, System.EventArgs e)
        {
            var stack = Navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != typeof(AddClient))
                await Navigation.PushAsync(new AddClient());
        }
        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ManageClient
            {
                BindingContext = e.SelectedItem as Clientes
            });
        }
    }
}
