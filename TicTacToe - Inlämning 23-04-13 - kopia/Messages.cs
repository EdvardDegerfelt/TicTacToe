using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictac
{
    public abstract class Messages : PlayerMove
    {
        public Messages()
        {

        }
        protected virtual void GameState() { }//gör så victorymessages overridear den beroende på antalet vinster

    }
}
