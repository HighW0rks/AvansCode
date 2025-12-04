using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var url = "https://api-acc.vattenfall.nl/api/vfnl/consumptions/v1/DynamicTariff";

        using HttpClient client = new();

        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Add("Ocp-Api\u006d-Subscription-Key", "4bfcc75549d04d2b8e8b94aebe67614f");
        client.DefaultRequestHeaders.Add("Origin", "https://www.vattenfall.nl");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);
            Console.WriteLine($"Status: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received data:");
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine("Request failed. Response body:");
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine(error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
