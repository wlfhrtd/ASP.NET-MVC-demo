using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


namespace Mvc.Services.Logging
{
    public class AppLogging<T> : IAppLogging<T>
    {
        private readonly ILogger<T> logger;

        private readonly IConfiguration config;

        private readonly string applicationName;


        public AppLogging(ILogger<T> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
            applicationName = config.GetValue<string>("ApplicationName");
        }


        public void LogAppCritical(
            Exception exception,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(exception, message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppCritical(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppDebug(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppError(
            Exception exception,
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(exception, message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppError(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppInformation(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppTrace(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        public void LogAppWarning(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var list = PushProperties(memberName, sourceFilePath, sourceLineNumber);
            logger.LogError(message);
            foreach (var item in list) item.Dispose();
        }

        internal List<IDisposable> PushProperties(
            string memberName,
            string sourceFilePath,
            int sourceLineNumber)
        {
            return new()
            {
                LogContext.PushProperty("MemberName", memberName),
                LogContext.PushProperty("FilePath", sourceFilePath),
                LogContext.PushProperty("LineNumber", sourceLineNumber),
                LogContext.PushProperty("ApplicationName", applicationName),
            };
        }
    }
}
