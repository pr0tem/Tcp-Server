using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace ConsoleApp1
{

    class Program
    {

        private static void Main()
        {
            //import classes
            ConnectionManeger connection = new ConnectionManeger();
            ThreadManeger thread = new ThreadManeger();
            
            //creates lists for sockets and threads
            List<Socket> socketArr = new List<Socket>();
            List<Thread> threadArr = new List<Thread>();
            
            //start the server
            TcpListener server = connection.StartServer();

            while (true)
            {
                //create a socket bound to a thread and add it to te list if a connection is pending
                if (server.Pending())
                {
                    Socket tempSocket = server.AcceptSocket();
                    socketArr.Add(tempSocket);
                    Thread tempThread = new Thread(() => thread.ThreadReadBytes(tempSocket));
                    threadArr.Add(tempThread);
                    tempThread.Start();
                }
            }
        }
    }
}
