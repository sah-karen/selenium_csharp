using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Tests.Common;

namespace Tests.Tests
{
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteTextToTextArea()
        {
            var expected = "Received!";
            var text = Guid.NewGuid().ToString();
            var message = WebForm
                .WriteTextToTextArea(text)
                .SubmitForm()
                .GetMessage();
            Assert.That(message, Is.EqualTo(expected));
        }
    }
}