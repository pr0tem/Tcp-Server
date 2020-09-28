using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class ConnectionManeger
    {
        //create and start the tcplistner, returns a server object
        public TcpListener StartServer()
        {
            TcpListener server = null;
            try
            {
                IPAddress addr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(addr, 13000);
                server.Start();
                Console.WriteLine("server started in {0}", addr);
                return server;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }

        //read bytes form socket and covert said bytes to string, returns a string
        //ended up not using here, but used it in the "ThreadManeger" class
        //maybe used in the future???
        public string ReadBytes(Socket s)
        {
            byte[] b = new byte[100];
            int k = s.Receive(b);
            string szReceived = System.Text.Encoding.ASCII.GetString(b, 0, k);
            string ClientIP = s.RemoteEndPoint.ToString();
            Console.WriteLine(ClientIP + ":" + szReceived);
            return ClientIP + ":" + szReceived;
        }
    }
}
