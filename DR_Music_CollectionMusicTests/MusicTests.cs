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
            _testMusicController = new MusicController();
            _testMusic = new MusicRecords(8, "UnitTest", "Test", "Test", "Test Records", 69, 2020);
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
            _testMusicController.Post(_testMusic);
            Assert.AreEqual(8, _testMusic.Id);
        }

        [TestMethod()]
        public void TestDeleteMethod()
        {
           
            int musicCount = _testMusicController.Get().Count();
            int expectedMusicCount = musicCount + 1;

            MusicRecords mr1 = new MusicRecords(200, "DeleteTest", "DeleteTest", "DeleteTest", "DeleteTest", 200, 2020);
            _testMusicController.Post(mr1);

            Assert.AreEqual(_testMusicController.Get().Count(), expectedMusicCount);

            int expectedMusicCountAfter = _testMusicController.Get().Count() - 1;

            _testMusicController.Delete(200);
            Assert.AreEqual(_testMusicController.Get().Count(), expectedMusicCountAfter);

            //Assert.AreEqual(200, mr1.Id);
        }

        [TestMethod()]
        public void TestPutMethod()
        {
            //MusicRecords mr1 = new MusicRecords(200, "PutTest", "PutTest", "PutTest", "PutTest", 200, 2020);

            ////_testMusicController.Put(300,mr1);
            //_testMusicController.Put(300, new MusicRecords(300, "PutTestAfter", "PutTestAfter", "PutTestAfter", "PutTestAfter",300,2021));

            //Assert.AreEqual(300, mr1.Id);


        }
    }
}