using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Staff_Schedulling_System.Admin;
using Staff_Schedulling_System;
using System.Linq;

namespace ShedullingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var age = (Math.Floor((DateTime.Now - DateTime.Now.AddYears(-24)).TotalSeconds / 31556952)).ToString();
            //Assert.AreEqual(age, "24");
            //string[] DaysOfWeek = { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
            //var todays = DateTime.Now;
            //var d = todays.DayOfWeek;

            //var dd = DaysOfWeek.ToList().IndexOf(todays.DayOfWeek.ToString().ToUpper()) + 1;
            //Assert.AreEqual(dd, 7);


            new Controls().SetShift("S/16/2018/9/3", "W/15/2018/9/1");

        }

    }
}
