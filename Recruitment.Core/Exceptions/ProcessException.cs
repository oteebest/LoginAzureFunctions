using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Core.Exceptions
{
 
    [Serializable()]
    public class ProcessException : Exception
    {
        public ProcessException(string message) :
            base(message)
        {

        }
    }
}
