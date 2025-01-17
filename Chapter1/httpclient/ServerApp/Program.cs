using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace ServerApp
{
    class Program
    {
        static void ProcessMessage(object parm) {
            string data;
            int count;
            try
            {
                TcpClient tcpClient = parm as TcpClient;
                //buffer for reading data
                Byte[] bytes = new Byte[256];
                // get a stream object for reading and writing
                NetworkStream stream = tcpClient.GetStream();
                //loop to receive all the data sent by client
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    //translate data bytes to ascii string
                    data=System.Text.Encoding.UTF8.GetString(bytes,0,count);
                    Console.WriteLine($"Receive: {data} at {DateTime.Now:t}");
                    //process the data sent by the client
                    data=$"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(data);
                    //send back a response
                    stream.Write(msg,0,msg.Length);
                    Console.WriteLine($"Sent: {data}");
                }
            }
            catch (Exception ex) {
                Console.WriteLine("{0}",ex.Message);
                Console.WriteLine("Writing message ...");
            }
            
        }
        static void ExecuteServer(string host, int port) {
            int Count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "Server Application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                //start listening for client request
                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("waiting for a connection...");
                //entering the listening loop
                while (true)
                {
                    //performing a blocking call to accept request
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"Number of client connected: {++Count}");
                    Console.WriteLine(new string('*', 40));
                    //create a thread to receive and send message
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("server stopped. press any key to exit.");
            }
            Console.Read();
            
        }

        public static void Main(string[] args)
        {
            string host = "127.0.0.1";
            //set TcpListener on port 13000
            int port = 13000;
            ExecuteServer(host, port);
        }

    }
}