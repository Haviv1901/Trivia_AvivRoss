using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trivia_Frontend_AvivRoss
{
    internal class TriviaRequests
    {
        public static TriviaRequests? instance = null;
        
        private string username;
        private int status;
        
        private Communicator _communicator;
        private bool _connected;
        public TriviaRequests()
        {
            status = Constants.LoginMenu;
            instance = this;
            
            _connected = false;
            _communicator = new Communicator();
            
            try
            {
                _communicator.Connect();
                _connected = true;
            }
            catch (Exception e)
            {
                _connected = false;
                Console.WriteLine(e);
                throw;
            }
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }
        public void SetStatus(int status)
        {
            this.status = status;
        }
        public int GetStatus()
        {
            return status;
        }
        public string GetUsername()
        {
            return username;
        }
        public void Disconnect()
        {
            _communicator.Disconnect();
        }

        public bool IsConnected()
        {
            return _connected;
        }

        public bool Login(string username, string password)
        {
            JObject send = new JObject();
            send.Add("username", username);
            send.Add("password", password);
            _communicator.SendMessage(send, Constants.LoginCode);
            Message recvMessage = _communicator.RecvMessage();

            
            JObject json = JObject.Parse(recvMessage.data);
            try
            {
                if (json["status"].ToString() == "1")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Register(string username, string password, string email)
        {
            JObject send = new JObject();
            send.Add("username", username);
            send.Add("password", password);
            send.Add("email", email);
            _communicator.SendMessage(send, Constants.LoginCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);
            try
            {
                if (json["status"].ToString() == "1")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
