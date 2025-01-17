using System.Net;
namespace ex2
{
    class Program
    {
        //httpclient is intended to be instantiated once per application
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            string uri = "https://www.contoso.com/";
            //call asynchronos network methods in a try catch block to handle exception
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(uri);
                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
            }
        }

        static void Main(string[] args)
        {

        }
    }
}