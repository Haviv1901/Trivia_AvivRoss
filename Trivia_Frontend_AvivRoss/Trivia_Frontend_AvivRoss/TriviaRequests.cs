﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Trivia_Frontend_AvivRoss
{
    public class TriviaRequests
    {
        public static TriviaRequests? instance = null;
        
        private int status; // meaningless - TODO: remove this
        
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

        public void LeaveGame()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.LeaveGameCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> username - avgAnswerTime - correctAnswerCount - isWinner </returns>
        public List<Tuple<string, float, int, bool>> GetGameResult()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.GetGameResultCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            List<Tuple<string, float, int, bool>> result = new List<Tuple<string, float, int, bool>>();

            foreach (var username in json)
            {
                string name = username.Key;
                float avgAnswerTime = username.Value["averageAnswerTime"].ToObject<float>();
                int correctAnswerCount = username.Value["correctAnswerCount"].ToObject<int>();
                bool isWinner = username.Value["isWinner"].ToObject<bool>();

                result.Add(new Tuple<string, float, int, bool>(name, avgAnswerTime, correctAnswerCount, isWinner));
            }

            return result;
        }


        /// <summary>
        /// function will return the correct answer id, return -1 if failed
        /// </summary>
        /// <param name="answerId"></param>
        /// <returns></returns>
        public int SendAnswer(int answerId)
        {
            JObject send = new JObject();
            send["Answer Id"] = answerId;

            _communicator.SendMessage(send, Constants.SubmitAnswerCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            if (isError(json) != "")
            {
                return -1;
            }

            return json["correctAnswerId"].ToObject<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>strings are as follows : Question , then 4 answers, IDs: 0-1-2-3-</returns>
        public List<string> GetQuestion()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.GetQuestionCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            return new List<string>()
            {
                json["Question"].ToString(),
                json["0"].ToString(),
                json["1"].ToString(),
                json["2"].ToString(),
                json["3"].ToString()
            };
        }

        public void StartGame()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.StartGameCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);
        }

        public void CloseOrLeaveRoom()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.CloseOrLeaveRoomCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> tuple in this order: vector of players, has game begun, question count and answer timeout.  </returns>
        public Tuple<List<string>, bool, int, int> GetRoomState()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.GetRoomStateCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            if (isError(json) == "Invalid Code")
            {
                throw new GameStarted();
            }

            List<string> players = new List<string>();
            string jsonStr = json["Players"].ToString().Replace("\n", "").Replace("\r", ""); // removing newlines
            players = JsonConvert.DeserializeObject<List<string>>(jsonStr);
            
            return new Tuple<List<string>, bool, int, int>(
                players,
                bool.Parse(json["hasGameBegun"].ToString()),
                int.Parse(json["Question Count"].ToString()),
                int.Parse(json["Answer Timeout"].ToString()));
        }


        public Dictionary<string, float> GetHighScore()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.GetHighScoreCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            Dictionary<string, float> scores;

            string jsonSTR = json.ToString();
            scores = JsonConvert.DeserializeObject<Dictionary<string, float>>(jsonSTR);

            return scores;
        }

        public List<string> GetPersonalStats()
        {
            JObject send = new JObject();
            

            _communicator.SendMessage(send, Constants.GetPersonalStatsCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            List<string> stats = new List<string>();

            // list is: [0] Average Answer Time [1] Number of Correct Answers [2] Total Answers [3] Number of Games Played [4] Total Score
            stats.Add(json["Average Answer Time"].ToString());
            stats.Add(json["Correct Answers"].ToString());
            stats.Add(json["Total Answers"].ToString());
            stats.Add(json["Total Games"].ToString());
            stats.Add(json["Total Score"].ToString());

            return stats;
        }

        public Dictionary<string, int> GetRooms()
        {
            JObject send = new JObject();

            _communicator.SendMessage(send, Constants.GetRoomsCode);
            Message recvMessage = _communicator.RecvMessage();

            JObject json = JObject.Parse(recvMessage.data);

            Dictionary<string, int> rooms;

            string jsonSTR = json.ToString();
            rooms = JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonSTR);

            return rooms;
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

            JObject json = JObject.Parse(recvMessage.data);

            List<string> players = new List<string>();

            players = json["PlayersInRoom"].ToString().Split(',').ToList();

            return players;
            
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

        private string isError(JObject json)
        {
            if (json.ContainsKey("message"))
            {
                return json["message"].ToString();
            }

            return "";
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
