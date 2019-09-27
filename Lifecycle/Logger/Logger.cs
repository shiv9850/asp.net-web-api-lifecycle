using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Lifecycle.Logger
{
    public class Logger<T> : ILogger<T> where T: class
    {
        private static int counter = 0;
        private static readonly NLog.Logger NLogger = NLog.LogManager.GetLogger((typeof(T)).ToString(),(typeof(T)));
        public Logger()
        {
        }

        public void Trace(string message)
        {
            NLogger.Log(NLog.LogLevel.Trace, message);
        }

        public void Debug(string message)
        {
            NLogger.Log(NLog.LogLevel.Debug, message);
        }


        public void Info(string message)
        {
            NLogger.Log(NLog.LogLevel.Info, $"{++counter} : {message} {Environment.NewLine}");
        }


        public void Error(string message)
        {
            NLogger.Log(NLog.LogLevel.Error, message);
        }

        public void Warn(string message)
        {
            NLogger.Log(NLog.LogLevel.Warn, message);
        }


        public void Trace(HttpRequestMessage request)
        {
            NLogger.Log(NLog.LogLevel.Trace, request);
        }

        public void Debug(HttpRequestMessage request)
        {
            NLogger.Log(NLog.LogLevel.Debug, request);
        }


        public void Info(HttpRequestMessage request)
        {
            NLogger.Log(NLog.LogLevel.Info, $"{++counter} : ", request,$"{Environment.NewLine}");
        }


        public void Error(HttpRequestMessage request)
        {
            NLogger.Log(NLog.LogLevel.Error, request);
        }

        public void Warn(HttpRequestMessage request)
        {
            NLogger.Log(NLog.LogLevel.Warn, request);
        }

        public void Exception(Exception exception, string message = "")
        {
            NLogger.Error(exception, message);
        }
    }
}