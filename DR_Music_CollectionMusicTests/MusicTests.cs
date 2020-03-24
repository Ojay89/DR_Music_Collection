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
        private MusicRecords _testMusic;
        private MusicController _testMusicController;

        [TestInitialize]
        public void InitTestMusic()
        {
            _testMusic = new MusicRecords(100, "Novembervej", "Nik & Jay", "Novembervej", "Nik & Jay Records", 68, 2010);
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