using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Linq;

class Program
{
    const string APIKEY = "3340b06b60c84fedcfbd0d168b1dcc42";
    static async Task Main()
    {
        List<Weather> points = new();
        Random rnd = new();
        using (HttpClient client = new())
        {
            while (points.Count < 50)
            {
                double lat = rnd.NextDouble() * 180 - 90; // случайная широта от -90 до 90
                double lon = rnd.NextDouble() * 360 - 180; // случайная долгота от -180 до 180

                string path = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={APIKEY}";
                Weather point;
                //Console.WriteLine(path);
                using var response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    /*point = */
                    var dataString = await response.Content.ReadAsStringAsync();
                    var data = JObject.Parse(dataString);
                    //Console.WriteLine(data);
                    point = new();
                    try
                    {
                        point.Country = (string)data["sys"]["country"];
                        point.Name = (string)data["name"];
                        point.Temp = Convert.ToDouble(data["main"]["temp"]) - 273.15; // Convert from Kelvin to Celsius
                        point.Description = (string)data["weather"][0]["description"];
                        if (string.IsNullOrEmpty(point.Country) || string.IsNullOrEmpty(point.Name))
                        {
                            continue;
                        }
                        //Console.WriteLine($"R{point.Temp}R");
                        points.Add(point);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex);
                        //Thread.Sleep(5_000);
                        continue;
                    }
                    //Console.WriteLine(data);
                }
                //Console.WriteLine(response);
            }
        }
        //Console.WriteLine(points[0]);
        //Console.WriteLine(points.Count);
        
        Weather maxTempPoint = points.Aggregate((minItem, nextItem) => minItem.Temp < nextItem.Temp ? minItem : nextItem);
        Weather minTempPoint = points.Aggregate((maxItem, nextItem) => maxItem.Temp > nextItem.Temp ? maxItem : nextItem);
        Console.WriteLine($"The countries with:" +
            $"\n\tmin temp: {minTempPoint.Country}" +
            $"\n\tmax temp: {maxTempPoint.Country}");
        
        double averageTemp = points.Average(point => point.Temp);
        Console.WriteLine($"Average temperature is {averageTemp:F2} °C");

        int countryCount = points.GroupBy(point => point.Country).Count();
        Console.WriteLine($"The count of unique countries is {countryCount}"); 
        
        Weather ll = points.SkipWhile(point => point.Description != "clear sky" && point.Description != "rain" && point.Description != "few clouds").FirstOrDefault();
        Console.WriteLine(ll);
    }

    public struct Weather
    {
        public string Country { get; set; }
        public string Name { get; set; }
        public double /*string*/ Temp { get; set; }
        public string Description { get; set; }
        public override string ToString() => $"Country: {Country}, Name: {Name}, Temp: {Temp}, Description: {Description}";
    }
}