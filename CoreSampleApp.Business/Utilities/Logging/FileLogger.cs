using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoreSampleApp.Core.ENUMS;
using CoreSampleApp.Utilities.Extensions;
using Microsoft.Extensions.Configuration;

namespace CoreSampleApp.Business.Utilities.Logging
{
    public class FileLogger : ILogger
    {
        private string _logFilePath;
        public string LogFilePath
        {
            set
            {
                _logFilePath = value;
                if (!File.Exists(_logFilePath))
                {
                    File.Create(_logFilePath).Dispose();
                }
            }
        }
        public FileLogger(string logFilePath)
        {
            LogFilePath = logFilePath;            
        }

        public void Dispose()
        {
            _logFilePath = null;
        }

        public void LogEntry(Exception ex, string message = null)
        {
            using (StreamWriter sw = File.AppendText(_logFilePath))
            {

            }
        }

        public void LogEntry(LOGGINGMESSAGETYPES messagetype, string message)
        {
            using (StreamWriter sw = File.AppendText(_logFilePath))
            {
                sw.WriteLine($"{messagetype.GetDescription()}:\t{message}");
            }
        }
    }
}
