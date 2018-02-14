using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace XamarinRest.Models
{
    
    public class RestClient
    {
        HttpClient myClient = new HttpClient();
        public RestClient()
        {

        }
        public async Task<List<Clientes>> GetClient()
        {
            var response = await myClient.GetStringAsync("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/client");
            var clientes = JsonConvert.DeserializeObject<List<Clientes>>(response);
            return clientes;
        }
        public async Task<int> PostClient(Clientes itemToAdd)
        {
            try
            {
                var data = JsonConvert.SerializeObject(itemToAdd);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await myClient.PostAsync("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/client", content);
                var result = JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return 0;
            }

        }
       public async Task<int> PutClient(string itemIndex, Clientes itemToUpdate)
        {
            try
            {
                var data = JsonConvert.SerializeObject(itemToUpdate);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await myClient.PutAsync(string.Concat("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/client/", itemIndex), content);
                return JsonConvert.DeserializeObject<int>(response.Content.ReadAsStringAsync().Result);
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
                return 0;
            }
        }

        public async Task DeleteClient(string itemIndex)
        {
            try
            {
                await myClient.DeleteAsync(string.Concat("http://ec2-54-245-141-110.us-west-2.compute.amazonaws.com/pizzafast/public/index.php/client/", itemIndex));
            }
            catch (System.Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }
        }
    }
}
