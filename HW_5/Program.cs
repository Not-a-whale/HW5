using System;

namespace HW_5
{
    class Program
    {
        public enum LogLevels 
        {
            Error, 
            Info,
            Warning
        }

        public struct Result
        {
            LogLevels status;
            string message;
            DateTime timestamp;

            const string errorMessage = "You've got an error!";
            const string infoMessage = "You've been informed!";
            const string WarningMessage = "This is a Warning for you!";

            public Result(string message = errorMessage, LogLevels status = LogLevels.Info, DateTime time = new DateTime())
            {
                this.status = status;
                this.timestamp = time;
                if (status == LogLevels.Error)
                {
                    this.message = errorMessage;
                }
                if (status == LogLevels.Info)
                {
                    this.message = infoMessage;
                }
                if (status == LogLevels.Warning)
                {
                    this.message = WarningMessage;
                } else
                {
                    this.message = message;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
         

    }
}
