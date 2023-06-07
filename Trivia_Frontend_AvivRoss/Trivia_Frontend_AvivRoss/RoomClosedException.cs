using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Frontend_AvivRoss
{
    public class RoomClosedException : Exception
    {
        public RoomClosedException()
        {
        }

        public RoomClosedException(string message)
            : base(message)
        {
        }

        public RoomClosedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
