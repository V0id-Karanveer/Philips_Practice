using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    

    [TestFixture]
    class InstallerHelperTests
    {
        private Mock<IDownloadFile> _downloadFile;
        private InstallerHelper _installerHelper;

        [SetUp]
        public void SetUp()
        {

            _downloadFile = new Mock<IDownloadFile>();
            _installerHelper = new InstallerHelper(_downloadFile.Object);
            
        }

        [Test]
        public void DownloadInstaller_NoEx_True()
        {
            _downloadFile.Setup(id => id.Download("test", "test"));
            var res = _installerHelper.DownloadInstaller("test", "test");
            Assert.That(res, Is.True);
        }

        [Test]

        public void DownloadInstaller_Ex_False()
        {
            _downloadFile.Setup(fd =>
                    fd.Download(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }

    }
}
