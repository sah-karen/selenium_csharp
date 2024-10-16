using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allure.NUnit.Attributes;

namespace Utils.Reports
{
    public class AllureReporting
    {
        [AllureStep("{0}")]
        public void LogStep(string message) 
        {

        }
    }
}