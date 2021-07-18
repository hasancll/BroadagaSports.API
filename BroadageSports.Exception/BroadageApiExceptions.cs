using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Exceptions
{
    public class BroadageApiExceptions:Exception
    {
        public BroadageApiExceptions(string message):base(message)
        {

        }
    }
}
