using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorSS
{
    interface Command
    {
        void Execute();
        void UnExecute();
    }
}
