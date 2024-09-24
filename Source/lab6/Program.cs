using System;
using System.IO;

class Program
{
    const string APIKEY = "3340b06b60c84fedcfbd0d168b1dcc42";
    List<Weather> points = new();
    static async Task Main()
    {
        Random rnd = new();
        using (HttpClient client = new())
        {
            //while (points.Count < 50)
            {
                double lat = rnd.NextDouble() * 180 - 90; // случайная широта от -90 до 90
                double lon = rnd.NextDouble() * 360 - 180; // случайная долгота от -180 до 180

                string path = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={APIKEY}\r\n";
                //Weather point;
                Console.WriteLine(path);
                using HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    /*point = */
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                Console.WriteLine(response);
            }
        }
    }

    struct Weather
    {
        string Country, Name;
        double Temp;
        string Description;
    }
}