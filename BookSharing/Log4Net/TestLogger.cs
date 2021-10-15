using BookSharing.ComponentHelper;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSharing.Log4Net
{
    [TestClass]
    public class TestLogger
    {
        [TestMethod()]
        public void TestLog4Net()
        {
            //create the layout 

            //var patternLayout = new PatternLayout();
            //patternLayout.ConversionPattern = "%date{dd-MM-yyyy-HH:mm:ss} [%class] [%level] [%method] - %message%newline";
            //patternLayout.ActivateOptions(); 

            ////use this layout in the appender(where the log output stores)
            //var consoleAppender = new ConsoleAppender()
            //{
            //    Name = "ConsoleAppender",
            //    Layout = patternLayout,
            //    Threshold = Level.Error //capture all the log info
            //};
            //consoleAppender.ActivateOptions();

            //var fileAppender = new FileAppender()
            //{
            //    Name = "fileAppender",
            //    Layout = patternLayout,
            //    Threshold =Level.All,
            //    AppendToFile = true,
            //    File ="FileLogger.log"
            //};
            //fileAppender.ActivateOptions();

            ////rolling logger
            //var rollingAppender = new RollingFileAppender()
            //{ 
            //    Name = "Rolling File Appender",
            //    AppendToFile = true,
            //    File = "RollingLogger.log",
            //    Layout = patternLayout,
            //    Threshold = Level.All,
            //    MaximumFileSize = "1MB", // max size of a log file
            //    MaxSizeRollBackups = 15  // create the backup upto 15 log files as file1.log, file2.log.....file15.
            //};
            //rollingAppender.ActivateOptions();


            ////initialize the configuration
            //BasicConfigurator.Configure(consoleAppender, fileAppender, rollingAppender);

            //get the instance of the logger
            
            ILog Logger = Log4netHelper.GetLogger(typeof(TestLogger));


            Logger.Debug("This is debug information");
            Logger.Info("This is Info information");
            Logger.Warn("This is Warn information");
            Logger.Error("This is Error information");
            Logger.Fatal("This is Fatal information");

        }

        [TestMethod]
        public void TestLog4NetSec()
        {
            //get the instance of the logger
            Log4netHelper.Layout = "%message%newline";
            ILog Logger = Log4netHelper.GetLogger(typeof(TestLogger));


            Logger.Debug("This is debug information");
            Logger.Info("This is Info information");
            Logger.Warn("This is Warn information");
            Logger.Error("This is Error information");
            Logger.Fatal("This is Fatal information");

        }
    }
}
