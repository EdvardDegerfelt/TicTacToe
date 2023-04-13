using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictac
{
    public interface IColour
    {
        public string Color(string input); //Overridas i GameboardPrintout och sedan i GameLoop för färg, Kanske borde göras till abstract class för att få in inheritance, override och abstract klass.
        public string[] Color(string[] gameBoard); //Denna e shitty och bör tas bort Gör ist abstract på den metoden ovan, få in på gameboard t ex
    }
}
