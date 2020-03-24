using Microsoft.VisualStudio.TestTools.UnitTesting;
using DR_Music_Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestMusicService.Controllers;

namespace DR_Music_Collection.MusicTest
{
    [TestClass()]
    public class MusicTests
    {
        private Music _testMusic;
        private MusicController _testMusicController;

        [TestInitialize]
        public void InitTestMusic()
        {
            _testMusic = new Music(10, "12Novembervej", "12Nik & Jay", "12Novembervej", "12Nik & Jay Records", 31.10, 20110);
            _testMusicController = new MusicController();
        }

        [TestMethod()]
        public void TestGetAll()
        {
            int musicCount = _testMusicController.Get().Count();
            Assert.AreEqual(6,musicCount);
        }

    }
}