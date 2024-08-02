using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoContext> _videoContext;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();

            _videoContext = new Mock<IVideoContext>();

            _videoService = new VideoService(_fileReader.Object , _videoContext.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            var res = _videoService.ReadVideoTitle();
            Assert.That(res, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_ListOfVideos_ReturnCommaSeparatedList()
        {
            
            _videoContext.Setup(fr => fr.GetUnprocessed()).Returns(new List<Video>()
            {
                new Video()
                {
                    Id = 1,
                    IsProcessed = true,
                    Title = "abc"
                },
                new Video()
                {
                    Id = 2,
                    IsProcessed = false,
                    Title = "abc"
                },
                new Video()
                {
                    Id = 3,
                    IsProcessed = true,
                    Title = "abc"
                }
            });
            var res = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(res == "1,2,3");


        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideos_ReturnNull()
        {
            _videoContext.Setup(k => k.GetUnprocessed()).Returns(new List<Video>());
            var res = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(res.IsNullOrEmpty());
        }

    }
}
