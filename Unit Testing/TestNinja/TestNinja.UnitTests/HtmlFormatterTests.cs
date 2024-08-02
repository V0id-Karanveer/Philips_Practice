using System;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{

    [TestFixture]
    public class HtmlFormatterTests
    {

        [Test]
        public void FormatAsBold_Normal_ReturnsBold()
        {
            HtmlFormatter hf = new HtmlFormatter();

            var res = hf.FormatAsBold("abc");

            Assert.That(res, Is.EqualTo("<strong>abc</strong>"));

        }

        // Given , when , then
    }
}
