using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.ComponentHelper
{
    public class Log4netHelper
    {
        #region Field

        private static ILog _logger;
        private static ConsoleAppender _consoleAppender;
        private static FileAppender _fileAppender;
        private static RollingFileAppender _rollingFileAppender;
        private static string layout = "%date{dd-MM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";

        #endregion

        #region Property

        public static string Layout
        {
            set { layout = value; }
        }

        #endregion

        #region Private

        private static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = layout
            };
            patternLayout.ActivateOptions();

            return patternLayout;
        }

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All //capture all the log info
            };
            consoleAppender.ActivateOptions();

            return consoleAppender;
        }

        private static FileAppender GetFileAppender()
        {
            var fileAppender = new FileAppender()
            {
                Name = "fileAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                AppendToFile = true,
                File = "FileLogger.log"
            };
            fileAppender.ActivateOptions();

            return fileAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "Rolling File Appender",
                AppendToFile = true,
                File = "RollingLogger.log",
                Layout = GetPatternLayout(),
                Threshold = Level.All,
                MaximumFileSize = "1MB", // max size of a log file
                MaxSizeRollBackups = 15  // create the backup upto 15 log files as file1.log, file2.log.....file15.log
            };
            rollingFileAppender.ActivateOptions();

            return rollingFileAppender;
        }

        #endregion
        #region Public

        public static ILog GetLogger(Type type)
        {

            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_fileAppender == null)
                _fileAppender = GetFileAppender();

            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if (_logger != null)
                return _logger;

            //initialize the configuration
            BasicConfigurator.Configure(_consoleAppender, _fileAppender, _rollingFileAppender);

            //get the instance of the logger
            _logger = LogManager.GetLogger(type);
            return _logger;

        }

        #endregion

    }
}
