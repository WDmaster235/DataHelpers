using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelpers
{
    public class DataHelpersException : Exception
    {
        public DataHelpersException(string exception) : base(exception) { }
        
    }
    public class EmptyException : DataHelpersException
    {
        public EmptyException(string exception) : base(exception) { }
    }
}
