using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientApp;
class Program
{
    static void ConnectServer(String server, int port)
    {
        string message, responseData;
        int bytes;
        try
        {
            //create a tcpclient
            TcpClient client = new TcpClient(server, port);
            Console.Title = "Client Application";
            NetworkStream stream = null;
            while (true)
            {
                Console.WriteLine("Input message <press Enter to exit>");
                message = Console.ReadLine();
                if(message == string.Empty)
                {
                    break;
                }
                //translate the passed message into ascii and store it as a byte array
                Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
                //get a client stream for reading and writing
                stream = client.GetStream();
                //send the message to the connected tcpserver
                stream.Write(data, 0, data.Length);
                Console.WriteLine($"sent: {0}", message);
                //receive the tcpserever response
                //use buffer to store response by bytes
                data = new Byte[256];
                //read the first batch of tcpserver response bytes
                bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("receive: {0}", responseData);

            }
            //shutdown and end connection
            client.Close();
        }
        catch(Exception e) {
        
            Console.WriteLine("exception: {0}", e.Message);
        }
    }
    //end connection server

    static void Main(string[] args)
    {
        string server = "127.0.0.1";
        //set the tcplistener on port 13000
        int port = 13000;
        ConnectServer(server, port);
    }
}
