using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoreSampleApp.Core.ENUMS;
using Microsoft.Extensions.Configuration;

namespace CoreSampleApp.Business.Utilities.Logging
{
    public class FileLogger : ILogger
    {
        private string _logFilePath;
        public FileLogger(string logFilePath)
        {
            _logFilePath = logFilePath;
            if (!File.Exists(_logFilePath))
            {
                File.CreateText(_logFilePath);
            }
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

            }
        }
    }
}
