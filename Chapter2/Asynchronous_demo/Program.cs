using System;
using System.Net;

class Program
{
    //using event-based asyn pattern(eap)
    private static void DownloadAsynchronously()
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadComplete);
        client.DownloadStringAsync(new Uri("http://www.aspnet.com"));

    }

    private static void DownloadComplete(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            Console.WriteLine("Some error has occured.");
            return;
        }
        //print result
        Console.WriteLine(e.Result);
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("download complete");
    }

    static void Main(string[] args)
    {
        DownloadAsynchronously();
        Console.WriteLine("Main thread: done");
        Console.WriteLine(new string('*', 30));
        Console.ReadLine();
    }
}
