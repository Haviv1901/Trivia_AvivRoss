using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Trivia_Frontend_AvivRoss
{
    static class Constants
    {
        public const string ServerIp = "127.0.0.1";
        public const int ServerPort = 6969;

        public const int ErrorCode = 0;
        public const int LoginCode = 10;
        public const int SignUpCode = 12;
        public const int MenuCode = 20;
        public const int SignOutCode = 21;
        public const int GetRoomsCode = 22;
        public const int GetPlayersInRoomCode = 23;
        public const int GetPersonalStatsCode = 24;
        public const int GetHighScoreCode = 25;
        public const int JoinRoomCode = 26;
        public const int CreateRoomCode = 27;
        public const int LastMenuCode = 28;

        public const int CloseOrLeaveRoomCode = 30;
        public const int StartGameCode = 31;
        public const int GetRoomStateCode = 32;
        public const int LastRoomCode = 33;

        public const int GameCodes = 40;
        public const int LeaveGameCode = 41;
        public const int GetQuestionCode = 42;
        public const int SubmitAnswerCode = 43;
        public const int GetGameResultCode = 44;
        public const int LastGameCodes = 45;

        public const int LoginMenu = 100;
        public const int MainMenu = 200;
        

    }
}
