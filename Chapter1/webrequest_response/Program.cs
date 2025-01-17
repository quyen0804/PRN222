using System.Net;
namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create a request for url
            WebRequest request = WebRequest.Create("https://www.contosos.com/default.html");
            //if required by the server, set the credentials
            request.Credentials = CredentialCache.DefaultCredentials;
            //get the response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //display status
            Console.WriteLine("Status: " + response.StatusDescription);
            Console.WriteLine(new string('*', 50));
            //get the stream containing content returned by the server
            Stream dataStream = response.GetResponseStream();
            //open the stream using StreamReader for easy access
            StreamReader reader = new StreamReader(dataStream);
            //read the content
            string responseFromServer = reader.ReadToEnd();
            //display the content
            Console.WriteLine(responseFromServer);
            Console.WriteLine(new string('*', 50));
            //clean up the stream and response
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}