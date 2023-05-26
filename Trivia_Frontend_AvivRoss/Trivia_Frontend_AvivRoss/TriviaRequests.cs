using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trivia_Frontend_AvivRoss
{
    public class TriviaRequests
    {
        public static TriviaRequests? instance = null;
        
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

        public bool JoinRoom(int roomId)
        {
            JObject send = new JObject();
            send.Add("Room Id", roomId);

            _communicator.SendMessage(send, Constants.JoinRoomCode);
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
        public List<string> GetPlayersInRoom(int roomId)
        {
            JObject send = new JObject();
            send.Add("Room Id", roomId);

            _communicator.SendMessage(send, Constants.GetPlayersInRoomCode);
            Message recvMessage = _communicator.RecvMessage();

            //JObject json = JObject.Parse(recvMessage.data);
            //string jsonSTR = json.ToString();

            var root = (JContainer)JToken.Parse(recvMessage.data);
            var list = root.DescendantsAndSelf().OfType<JProperty>().Where(p => p.Name == "PlayersInRoom").Select(p => p.Value.Value<string>());

            List<string> players = new List<string>();
            players = list.ToList();

            return players;

            //foreach (var player in json["PlayersInRoom"].ToList())
            //{
            //    players.Add(player.ToString());
            //}
            //return players;
        }

        public int CreateRoom(string roomName, int maxPlayers, int questionsCount, int answerTimeOut)
        {
            JObject send = new JObject();
            send.Add("Room Name", roomName);
            send.Add("Answer Time Out", questionsCount);
            send.Add("Max Users", maxPlayers);
            send.Add("Question Count", answerTimeOut);

            _communicator.SendMessage(send, Constants.CreateRoomCode);
            Message recvMessage = _communicator.RecvMessage();


            JObject json = JObject.Parse(recvMessage.data);
            try
            {
                return int.Parse(json["Room Id"].ToString());
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        public void Disconnect()
        {
            _communicator.Disconnect();
        }

        public bool IsConnected()
        {
            return _connected;
        }

        public void Logout()
        {
            JObject send = new JObject();
            _communicator.SendMessage(send, Constants.SignOutCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);
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
            _communicator.SendMessage(send, Constants.SignUpCode);
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

        public void SetStatus(int status)
        {
            this.status = status;
        }
        public int GetStatus()
        {
            return status;
        }

    }
}
