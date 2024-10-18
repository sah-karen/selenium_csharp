using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using TestsExtentReportsParallelExecution.Common;
using Utils.Reports;

namespace TestsExtentReportsParallelExecution.Tests
{
    [Parallelizable(ParallelScope.All)]
    internal class TestsExtentReports : TestBase
    {
        [Test]
        public void WriteTextToTextAreaTest()
        {
            ExtentParallelReporting.Instance.LogInfo("Starting test - submit form");
            var expected = "Received!";
            var text = Guid.NewGuid().ToString();
            var message = WebForm
                .WriteTextToTextArea(text)
                .SubmitForm()
                .GetMessage();
            Assert.That(message, Is.EqualTo(expected));
        }

        [Test]
        public void WriteTextToTextAreaNegativeTest()
        {
            ExtentParallelReporting.Instance.LogInfo("Starting negative test - submit form");
            var expected = "Received failed!";
            var text = Guid.NewGuid().ToString();
            var message = WebForm
                .WriteTextToTextArea(text)
                .SubmitForm()
                .GetMessage();
             Assert.That(message, Is.EqualTo(expected));
        }

    }
}