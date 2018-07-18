using CoreSampleApp.Core.ENUMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Utilities
{
    public interface ILogger : IDisposable
    {
        void LogEntry(Exception ex, string message = null);
        void LogEntry(LOGGINGMESSAGETYPES messagetype, string message);
    }
}
