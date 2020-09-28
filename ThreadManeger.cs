using System;
using System.Threading;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class ThreadManeger
    {
        // i robot of threads, clean the socket/thread lists
        public void Cleaner(List<Socket> s, List<Thread> t)
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < s.Count; i++)
                    {
                        if (s[i].Connected == null)
                        {
                            Thread.Sleep(5);
                        }
                        else if (s[i].Connected == false)
                        {
                            s[i].Close();
                            s.RemoveAt(i);
                            t[i].Interrupt();
                            t.RemoveAt(i);
                        }
                    }
                }
                catch (Exception)
                {

                }
            } 
        }
        
        //A thread task that read input from client
        public void ThreadReadBytes(Socket s)
        {
            string id = s.RemoteEndPoint.ToString();
            while (true)
            {
                try
                {
                    byte[] b = new byte[100];
                    int k = s.Receive(b);
                    string szReceived = System.Text.Encoding.ASCII.GetString(b, 0, k);
                    string ClientIP = s.RemoteEndPoint.ToString();
                    Console.WriteLine(ClientIP + ":" + szReceived);
                }
                catch(Exception)
                {
                    Console.WriteLine("{0} has disconnected", id);
                    break;
                }
            }
        }
    }
}
