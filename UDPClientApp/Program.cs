using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;

class Program
{
    static void ConnectServer(string host, int port)
    {
        UdpClient client = new UdpClient();
        IPAddress address = IPAddress.Parse(host);
        IPEndPoint remoteEndpoint = new IPEndPoint(address, port);
        string message;
        //IPEndPoint remoteEndPoint = new IPEndPoint(address, port);
        int count = 0;
        bool done = false;
        Console.Title = "UDP Client";
        try
        {
            Console.WriteLine(new string('*', 40));
            client.Connect(remoteEndpoint);
            while (!done)
            {
                message = $"Message {++count:D2}";
                byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                client.Send(sendBytes, sendBytes.Length);
                Console.WriteLine($"Sent: {message}");
                Thread.Sleep(2000);
                if (count == 10) //broadcast 10 message
                {
                    done = true;
                    Console.WriteLine("done");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
        finally
        {
            client.Close();
        }
    }

    static void Main(string[] args)
    {
        string host = "127.0.0.1";
        int port = 11000;
        ConnectServer(host, port);
        Console.Read();

    }
}