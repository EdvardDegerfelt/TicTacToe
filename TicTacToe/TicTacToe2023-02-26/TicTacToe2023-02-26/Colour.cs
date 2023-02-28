using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictac
{
    public interface IColour
    {
        public string Color(string input); //Overridas i GameboardPrintout och sedan i GameLoop för färg

    }
}
