using System;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_SetLog_LastErrorIsSet()
        {
            ErrorLogger EL = new ErrorLogger();

            EL.Log("Check");

            Assert.That(EL.LastError == "Check");

        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_NullLog_ThrowEx(string e)
        {
            ErrorLogger EL = new ErrorLogger();
            
            Assert.That(()=>EL.Log(e) , Throws.ArgumentNullException);
        }

        [Test]

        public void Log_StrPassed_Notify()
        {
            var logger = new ErrorLogger();
            var id = Guid.Empty;
            logger.ErrorLogged += ((sender, args) => id = args);
            logger.Log("a");
            Assert.That(id , Is.Not.EqualTo(Guid.Empty));

        }


    }
}
