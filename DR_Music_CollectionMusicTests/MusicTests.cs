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
            _testMusic = new MusicRecords(8, "UnitTest", "Test", "Test", "Test Records", 69, 2020);
            _testMusicController = new MusicController();
        }

        [TestMethod()]
        public void TestGetAll()
        {
            int musicCount = _testMusicController.Get().Count();
            Assert.AreEqual(6, musicCount);
        }

        [TestMethod()]
        public void TestGetOneID()
        {
            _testMusic = _testMusicController.Get(1);
            Assert.AreEqual(1, _testMusic.Id);
        }

        [TestMethod()]
        public void TestGetOneTitle()
        {
            _testMusic = _testMusicController.Get(1);
            Assert.AreEqual("Novembervej", _testMusic.Title);
        }

        [TestMethod()]
        public void TestPostMethod()
        {
            _testMusicController = new MusicController();
            _testMusicController.Post(_testMusic);
            Assert.AreEqual(8, _testMusic.Id);
        }

        [TestMethod()]
        public void TestDeleteMethod()
        {
            MusicRecords mr1 = new MusicRecords(200, "DeleteTest", "DeleteTest", "DeleteTest", "DeleteTest", 200, 2020);
            _testMusicController.Post(mr1);

            _testMusicController = new MusicController();
            int musicCount = _testMusicController.Get().Count();
            Assert.AreEqual(7,musicCount);

            _testMusicController.Delete(200);
            Assert.AreEqual(6, musicCount);


            //Assert.AreEqual(200, mr1.Id);


        }
    }
}