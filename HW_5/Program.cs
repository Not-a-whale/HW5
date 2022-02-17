using System;
using System.IO;
using System.Linq;

namespace HW_5
{
    class Program
    {
        private static Logger logger;
        private static string allText = "";
        public enum LogLevels 
        {
            Error, 
            Info,
            Warning
        }

        public struct Result
        {
            public LogLevels status;
            public string message;
            public DateTime timestamp;

            const string errorMessage = "You've got an error!";
            const string infoMessage = "You've been informed!";
            const string warningMessage = "This is a Warning for you!";

            public Result(DateTime time, string message = errorMessage, LogLevels status = LogLevels.Info)
            {
                this.status = status;
                this.timestamp = time;
                if (status == LogLevels.Error)
                {
                    this.message = errorMessage;
                } else 
                if (status == LogLevels.Info)
                {
                    this.message = infoMessage;
                } else 
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

            private static Logger instance;

            protected Logger(Result result) 
            {
                this.AddItem(result);
            }

            public static Logger GetInstance(Result res)
            {
                if(instance == null)
                {
                    instance = new Logger(res);
                }
                instance.AddItem(res);
                return instance;
            }
            public void LogItems(Result res)
            {
                string currentString;
                if (res.status == LogLevels.Error)
                {
                    foreach(Result log in this.errorArr)
                    {
                        currentString = $"{log.timestamp}: {log.status.ToString()}: {log.message}";
                        Console.WriteLine(currentString);
                        allText = allText + "\n" + currentString;
                    }
                } else 
                if (res.status == LogLevels.Warning)
                {
                    foreach (Result log in this.warningArr)
                    {
                        currentString = $"{log.timestamp}: {log.status.ToString()}: {log.message}";
                        Console.WriteLine(currentString);
                        allText = allText + "\n" + currentString;
                    }
                } else 
                if (res.status == LogLevels.Info)
                {
                    foreach (Result log in this.infoArr)
                    {
                        currentString = $"{log.timestamp}: {log.status.ToString()}: {log.message}";
                        Console.WriteLine(currentString);
                        allText = allText + "\n" + currentString;
                    }
                }
            }

            private void AddItem(Result result)
            {
                if(result.status == LogLevels.Error)
                {
                    Array.Resize(ref this.errorArr, this.errorArr.Length + 1);
                    this.errorArr[this.errorArr.Length - 1] = result;
                } else
                if (result.status == LogLevels.Info)
                {
                    Array.Resize(ref this.infoArr, this.infoArr.Length + 1);
                    this.infoArr[this.infoArr.Length - 1] = result;
                } else
                if (result.status == LogLevels.Warning)
                {
                    Array.Resize(ref this.warningArr, this.warningArr.Length + 1);
                    this.warningArr[this.warningArr.Length - 1] = result;
                }
            }
        }

        static class Actions
        {
            public static Result InfoAction()
            {
                return new Result(DateTime.Now, null, LogLevels.Info);
            }

            public static Result ErrorAction()
            {
                return new Result(DateTime.Now, null, LogLevels.Error);
            }

            public static Result WarningAction()
            {
                return new Result(DateTime.Now, null, LogLevels.Warning);
            }
        }

        static class Starter
        {
            public static void Run()
            {
                Random r = new Random();
                int randomNumber = r.Next(1, 10);

                for(int i = 0; i <= randomNumber; i++)
                {
                    Result LogAction;
                    Random randomNumForMethod = new Random();
                    int randomMethodNumber = randomNumForMethod.Next(1, 4);
                    if(randomMethodNumber == 1)
                    {
                        LogAction = Actions.InfoAction();
                        Program.logger = Logger.GetInstance(LogAction);
                        logger.LogItems(LogAction);
                    }
                    if(randomMethodNumber == 2)
                    {
                        LogAction = Actions.WarningAction();
                        Program.logger = Logger.GetInstance(LogAction);
                        logger.LogItems(LogAction);
                    }
                    if (randomMethodNumber == 3)
                    {
                        LogAction = Actions.ErrorAction();
                        Program.logger = Logger.GetInstance(LogAction);
                        logger.LogItems(LogAction);
                    }
                }
            }
        }

        static public void CreateAFile(string FileName)
        {
            string Path = "./" + FileName + ".txt";

            if (!File.Exists(Path))
            {
                File.Create("./" + FileName + ".txt").Close();
            }
        }


        static private void WriteFile(string Document, string FileName = "KornienkoProgramLogs")
        {
            string Path = "./" + FileName + ".txt";

            if (!File.Exists(Path))
            {
                Program.CreateAFile(FileName);
            }

            if (File.Exists(Path))
            {
                using (StreamWriter sw = new StreamWriter(Path))
                {
                    sw.Write(Document);
                    sw.Close();
                }
            }
        }

        static void Main(string[] args)
        {
            Program.Starter.Run();
            Program.WriteFile(Program.allText);
        }
         

    }
}
