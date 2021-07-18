using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API.Helper
{
    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty(this IEnumerable @this)
        {
            return @this == null || @this.GetEnumerator().MoveNext() == false;
        }
    }
}
