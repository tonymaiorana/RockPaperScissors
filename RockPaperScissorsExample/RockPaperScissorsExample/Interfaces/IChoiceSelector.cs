﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissorsExample.Enums;

namespace RockPaperScissorsExample.Interfaces
{
    public interface IChoiceSelector
    {
        Choice GetChoice();
    }
}
