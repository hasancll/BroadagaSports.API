using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BroadageSports.Middleware.BroadageSportsResponseHelper
{
    public class BroadagaSportsModel
    {
        public object Response { get; set; }
        public String StatusCode { get; set; }
        public String IsSuccess { get; set; }
        public String Message { get; set; }
    }
}
