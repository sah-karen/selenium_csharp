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
    public sealed class ExtentParallelReporting
    {
        private static ExtentParallelReporting instance = null;
        private static readonly object myLock = new object();
        private static readonly Dictionary<int,ExtentTest> extentMap = new Dictionary<int,ExtentTest>();
        private  ExtentReports? extentReports;
        private  ExtentTest extentTest;

        private ExtentParallelReporting()  { }

        public static ExtentParallelReporting Instance 
        {
            get
            {
                lock(myLock)
                {
                    if (instance == null)
                    {
                        instance = new ExtentParallelReporting();
                    }
                    return instance;
                }
            }
        }
        private ExtentReports StartReporting()
        {   
            lock(myLock)
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
        }
        public void CreateTest(string testName)
        {
            lock(myLock)
            {
                extentTest = StartReporting().CreateTest(testName);    
                extentMap.Add(Thread.CurrentThread.ManagedThreadId, extentTest);
            }
        }

        private ExtentTest GetExtentTest()
        {
            lock(myLock)
            {
                return extentMap[Thread.CurrentThread.ManagedThreadId];
            }
        }

        public void EndReporting()
        {
            lock(myLock)
            {
                StartReporting().Flush();
                extentMap.Remove(Thread.CurrentThread.ManagedThreadId);
            }
        }
        public void LogInfo(string info)
        {
            lock(myLock)
            {
                GetExtentTest().Info(info);
            }
        }

        public  void LogPass(string info)
        {
            lock(myLock)
            {
                GetExtentTest().Pass(info);
            }
        }
        public void LogFail(string info)
        {
            lock(myLock)
            {
                GetExtentTest().Fail(info);
            }
        }

        public void LogScreenShoot(string info, string image)
        {
            lock(myLock)
            {
                GetExtentTest().Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());   
            }
        }
    }
}