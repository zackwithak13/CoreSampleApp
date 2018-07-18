using CoreSampleApp.Core.ENUMS;
using CoreSampleApp.Utilities.SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreSampleApp.Business.Utilities
{
    public static class Logger
    {
        public static void Log(Exception ex, string message = null)
        {
            using (ILogger logger = Logger.Get())
            {
                logger.LogEntry(ex, message);
            }
        }

        public static void Log(LOGGINGMESSAGETYPES messagetype, string message)
        {
            using (ILogger logger = Logger.Get())
            {
                logger.LogEntry(messagetype, message);
            }
        }

        public static void LogTrace(string message)
        {
            using (ILogger logger = Logger.Get())
            {
                logger.LogEntry(LOGGINGMESSAGETYPES.Trace, message);
            }
        }

        /// <summary>
        /// helper to access a logger
        /// </summary>
        public static ILogger Get()
        {
            return SimpleInjectorAccessor.Container.GetInstance<ILogger>();
        }
    }
}
