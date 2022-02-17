using System;
using System.Linq;

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
            public LogLevels status;
            string message;
            DateTime timestamp;

            const string errorMessage = "You've got an error!";
            const string infoMessage = "You've been informed!";
            const string warningMessage = "This is a Warning for you!";

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
                    this.message = warningMessage;
                } else
                {
                    this.message = message;
                }
            }
        }

        class Logger
        {
            private Result[] errorArr = new Result[] { };
            private Result[] infoArr = new Result[] { };
            private Result[] warningArr = new Result[] { };
            private void LogItems()
            {

            }

            private void AddItem(Result result)
            {
                Result[] currentArr;

                if(result.status == LogLevels.Error)
                {
                    currentArr = this.errorArr;
                }
                if (result.status == LogLevels.Info)
                {
                    currentArr = this.infoArr;
                }
                if (result.status == LogLevels.Warning)
                {
                    currentArr = this.warningArr;
                } else
                {
                    currentArr = this.errorArr;
                }

                Array.Resize(ref currentArr, currentArr.Length + 1);
                currentArr[currentArr.GetUpperBound(0)] = result;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
         

    }
}
