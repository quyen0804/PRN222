using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPServerApp;

class Program
{
    const int listenPort = 11000;
    const string host = "127.0.0.1";
    private static void StartListener()
    {
        string message;
        UdpClient listener = new UdpClient(listenPort);
        IPAddress address = IPAddress.Parse(host);
        IPEndPoint remoteEndpoint = new IPEndPoint(address, listenPort);
        Console.Title = "UDP Server";
        Console.WriteLine(new string('*', 40));
        try
        {
            while (true)
            {
                Console.WriteLine("waiting for broadcast");
                byte[] bytes = listener.Receive(ref remoteEndpoint);
                message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"receive broadcast from {remoteEndpoint}: {message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            listener.Close();
        }
    }

    public static void Main()
    {
        Thread thread = new Thread(StartListener);
        thread.Start();
    }
}
