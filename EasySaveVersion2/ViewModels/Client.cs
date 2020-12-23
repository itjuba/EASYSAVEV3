﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace SocketWshop
{
    class Client
    {
        public static Socket SeConnecter()
            {
                Socket socket = null;
                try
                {
                    IPHostEntry host = Dns.GetHostEntry("localhost");  
                    IPAddress ipAddress = host.AddressList[0];
                    IPEndPoint remotEndPoint = new IPEndPoint(ipAddress, 11100);
                   socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                   socket.Connect(remotEndPoint);
                   socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
                   // Console.WriteLine("Socket connected to {0}", socket.RemoteEndPoint);  
                   Console.WriteLine("CONNECTED {0} ",socket.Connected);

                }
                catch (Exception e)  
                {  
                    Console.WriteLine(e.ToString());  
                }  
                return socket;
            }


        public static void EcouterReseau(Socket client,string message)
            {
                byte[] bytes = new byte[2048];  
                  
                    // Encode the data string into a byte array.  
                    // string s = string.Concat(message, "<EOF>");
                    // Console.WriteLine(s);
                    byte[] msg = Encoding.ASCII.GetBytes(message);  
                   
  
                    // Send the data through the socket.  
                    int bytesSent = client.Send(msg);
                    Console.WriteLine(bytesSent);
                    
                    // Receive the response from the remote device.  
                    int bytesRec = client.Receive(bytes);  
                    Console.WriteLine("recieved : "+bytesRec);
                    Console.WriteLine("Echoed test = {0}",  
                    Encoding.ASCII.GetString(bytes,0,bytesRec));
                    // client.Shutdown(SocketShutdown.Both);  
                    // client.Close();  
                    //
            }

        public static void Deconnecter(Socket socket)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
        // static void Main(string[] args)
        // {
        //   
        //    
        //      string d;
        //      do
        //      {
        //          Socket socket ;
        //          socket = SeConnecter();
        //          Console.WriteLine("write a message to send !");
        //          d = Console.ReadLine();
        //          EcouterReseau(socket, d);
        //          Deconnecter(socket);
        //      } while (d != "");
        //   
        //         
        //          
        //
        //     Console.WriteLine("out");
        //     // Deconnecter(socket);
        // }
    }
}