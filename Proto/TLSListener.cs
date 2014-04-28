using System;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Collections.Generic;



namespace Proto
{
    public class TLSListener
    {
        static NetworkStream libStream;

        /// <summary>
        /// simple method that closes the network stream.
        /// </summary>
        public static void Close()
        {
            libStream.Close();
        }

        /// <summary>
        /// Create a TCP/IP client socket.
        /// </summary>
        /// <param name="machineName">host running the server application</param>
        /// <param name="port">Port the host is listening on, default is 8000</param>
        public static void RunClient(string machineName, int port)
        {
            /*             
            try
            {
                TcpClient client = new TcpClient(machineName, port);
                client.Connect(machineName, port);
                Console.WriteLine("Client connected.");
                NetworkStream libStream = client.GetStream();
                // Encode a test message into a byte array. 
                // Signal the end of the message using the "<EOF>".
                byte[] messsage = Encoding.UTF8.GetBytes("{\"top_cmd\":\"login\",\"password\":\"admin\",\"user_name\":\"root\"}");
                // Send hello message to the server. 
                libStream.Write(messsage, 0, messsage.Length);
                libStream.Flush();
                // Read message from the server. 
                Dictionary<string, string> serverMessage = ReadMessage(libStream);
                Console.WriteLine("Server says: {0}", serverMessage["top_cmd"]);
                // Close the client connection.
                client.Close();
                Console.WriteLine("Client closed.");
            }
            catch (SocketException e)
            {
                Error_Msg em = new Error_Msg("20001", "Address incorrect.");
                em.Show();
            }*/
            TcpClient client = new TcpClient(machineName, port);
            Console.WriteLine("Client connected.");
            libStream = client.GetStream();
            // Encode a test message into a byte array. 
            // Signal the end of the message using the "<EOF>".
            // Send hello message to the server. 
            // Read message from the server. 
            // Close the client connection.
            Console.WriteLine("Client closed.");
        }

        /// <summary>
        /// Sends message to server
        /// </summary>
        /// <param name="msg">The message to be sent to the server</param>
        public static void SendMessage(string msg)
        {
            byte[] messsage = Encoding.UTF8.GetBytes(msg);
            libStream.Write(messsage, 0, messsage.Length);
            libStream.Flush();
        }

        /// <summary>
        /// Reads a message back from the server
        /// </summary>
        /// <returns>A map of param names and values</returns>
        public static Dictionary<string, string> ReadMessage()
        {
            byte[] buffer = new byte[1024];
            int size = libStream.Read(buffer, 0, buffer.Length);
            byte[] result = new byte[size];
            Array.Copy(buffer, 0, result, 0, size);
            Console.WriteLine("Server says: {0}", System.Text.Encoding.Default.GetString(result)); 
            string serverMessage = System.Text.Encoding.Default.GetString(result);
            Dictionary<string, string> map = MSGMultiplexer.jsonToMap(serverMessage);
            if (!map.ContainsKey("top_cmd"))
            {
                Error_Msg error = new Error_Msg("123", "no map");
                error.Show();
            }
            else if (map["top_cmd"] == "error")
            {
                Error_Msg error = new Error_Msg(map["code"], map["msg"]);
                error.Show();
            }
            return map;
        }

        /// <summary>
        /// Starts the conection to the remote server.
        /// </summary>
        /// <param name="machineName">The host machine's IP adress.</param>
        /// <param name="port">The port the host machine is listening on.</param>
        public static void startClient(string machineName, int port)
        {
            TLSListener.RunClient(machineName, port);
        }
    }
}