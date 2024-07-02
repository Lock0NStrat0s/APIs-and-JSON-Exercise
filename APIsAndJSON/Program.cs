using Newtonsoft.Json.Linq;

namespace APIsAndJSON;

public class Program
{
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();

        while (true)
        {
            string responseRon = GetResponse("https://ron-swanson-quotes.herokuapp.com/v2/quotes", client);
            string responseKanye = GetResponse("https://api.kanye.rest", client);

            JArray ron = JArray.Parse(responseRon);
            JObject kanye = JObject.Parse(responseKanye);

            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine($"RON: {ron[0]}\n");
            Console.WriteLine($"KANYE: {kanye["quote"]}");
            Console.WriteLine("--------------------------------------------------------------------------\n");

            Thread.Sleep(2000);
        }
    }

    private static string GetResponse(string url, HttpClient client)
    {
        return client.GetStringAsync(url).Result;
    }
}
