using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commands.exceptions
{
    class AssertionException : Exception
    {
        public AssertionException(string expected, string current) : base($"It was expected '{expected}' but was shown '{current}'") { }
    }
}
