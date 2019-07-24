using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TacitAssignment.Utility
{
    public interface ILogger
    {
        void Log(string logmessage);
    }
    public class Logger : ILogger
    {
        public void Log(string logmessage)
        {
            //Not doing here we can log to destination of choice and having mutiple logger implementing our interface
        }
    }
}