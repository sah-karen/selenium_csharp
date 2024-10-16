using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace Utils.Reports
{
    public sealed class ExtentReporting
    {
        private static ExtentReporting instance = null;
        private static readonly object myLock = new object();
        private  ExtentReports? extentReports;
        private  ExtentTest extentTest;

        private ExtentReporting()  { }

        public static ExtentReporting Instance 
        {
            get
            {
                lock(myLock)
                {
                    if (instance == null)
                    {
                        instance = new ExtentReporting();
                    }
                    return instance;
                }
            }
        }
        private ExtentReports StartReporting()
        {   
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\ ";
            if (extentReports ==null)
            {
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);
                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }
        public void CreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);    
        }

        public void EndReporting()
        {
            StartReporting().Flush();
        }
        public void LogInfo(string info)
        {
            extentTest.Info(info);
        }

        public  void LogPass(string info)
        {
            extentTest.Pass(info);
        }
        public void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public void LogScreenShoot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());   
        }

    }
}