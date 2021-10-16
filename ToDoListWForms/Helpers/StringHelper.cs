using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListWForms.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Ограничение длинны строки до n
        /// </summary>
        /// <param name="str"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string StopLengthUpToN(string str, int n)
        {
            return str?.Length > n ? $"{str?.Substring(0, n)}..." : str;
        }
    }
}
