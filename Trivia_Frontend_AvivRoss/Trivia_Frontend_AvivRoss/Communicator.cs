using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

struct Message
{
    public string data;
    public int code;
    public int length;
}


namespace Trivia_Frontend_AvivRoss
{
    internal class Communicator
    {
        private Socket _socket;

        public Communicator()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(Constants.ServerIp);
                IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, Constants.ServerPort);
                _socket.Connect(remoteEndPoint);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to server. try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public void Disconnect()
        {
            try
            {
                _socket.Disconnect(true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public void SendMessage(JObject data, int code)
        {
            try
            {
                _socket.Send(BuildMessage(JsonConvert.SerializeObject(data), code));
            }
            catch (Exception e)
            {
                Console.WriteLine("could not send message " + e.Message);
                throw;
            }
        }

        public Message RecvMessage()
        {
            Message recvMessage = new Message();
            byte[] buffer = new byte[4096];
            
            try
            {
                int bytesRead = _socket.Receive(buffer);
                if (bytesRead == 0)
                    throw new Exception("failed recving info.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return ParseMessage(buffer);

        }

        private Message ParseMessage(byte[] data)
        {
            Message parsedMessage = new Message();
            parsedMessage.code = data[0];
            byte[] lengthBytes = new byte[4];
            Array.Copy(data, 1, lengthBytes, 0, 4);
            Array.Reverse(lengthBytes);
            parsedMessage.length = BitConverter.ToInt32(lengthBytes);
            parsedMessage.data = System.Text.Encoding.ASCII.GetString(data, 5, parsedMessage.length);

            return parsedMessage;
        }

        private byte[] BuildMessage(string data, int code)
        {
            byte[] dataBytes = System.Text.Encoding.ASCII.GetBytes(data);
            byte codeBytes = (byte)code;
            int length = data.Count();
            byte[] lengthBytes = BitConverter.GetBytes(length);
            Array.Reverse(lengthBytes);

            List<byte> dataFull = new List<byte>();


            dataFull.Add(codeBytes);
            dataFull.AddRange(lengthBytes);
            dataFull.AddRange(dataBytes);


            return dataFull.ToArray();
        }
    }
}
