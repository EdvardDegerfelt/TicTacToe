﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tictac
{
    internal interface IGame : IColour

    {
        void WelcomeAndGameRules();
        void Start();
       
    }
}
