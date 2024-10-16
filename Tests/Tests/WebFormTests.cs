using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Tests.Common;
using Utils.Reports;

namespace Tests.Tests
{
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteTextToTextAreaTest()
        {
            ExtentReporting.Instance.LogInfo("Starting test - submit form");
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
            ExtentReporting.Instance.LogInfo("Starting negative test - submit form");
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