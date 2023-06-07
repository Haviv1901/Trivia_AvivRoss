using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia_Frontend_AvivRoss
{
    public class GameStarted : Exception
    {

        public GameStarted()
        {
        }

        public GameStarted(string message)
            : base(message)
        {
        }

        public GameStarted(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
