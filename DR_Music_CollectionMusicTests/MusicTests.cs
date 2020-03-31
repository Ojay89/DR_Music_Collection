using Microsoft.VisualStudio.TestTools.UnitTesting;
using DR_Music_Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RestMusicService.Controllers;

namespace DR_Music_Collection.MusicTest
{
    [TestClass()]
    public class MusicTests
    {
        private MusicRecords _testMusic;
        private MusicRecordsController _testMusicController;
        MusicRecordsDBContext dbContext = new MusicRecordsDBContext(new DbContextOptions<MusicRecordsDBContext>());

        [TestInitialize]
        public void InitTestMusic()
        {
            _testMusicController = new MusicRecordsController(dbContext);
            _testMusic = new MusicRecords(8, "UnitTest", "Test", "Test", "Test Records", 69, 2020);
            _testMusicController.PostMusicRecords(_testMusic);
        }

        [TestMethod()]
        public void TestGetAll()
        {
            int musicCount = _testMusicController.GetInMemoryMusicRecords().Result.Value.Count();
            Assert.AreEqual(1, musicCount);
        }

        //[TestMethod()]
        //public void TestGetOneID()
        //{
        //    _testMusic = _testMusicController.(8).Result.Value;
        //    Assert.AreEqual(8, _testMusic.Id);
        //}

        //[TestMethod()]
        //public void TestGetOneTitle()
        //{
        //    _testMusic = _testMusicController.GetInMemoryRecord(8).Result.Value;
        //    Assert.AreEqual("UnitTest", _testMusic.Title);
        //}

        //[TestMethod()]
        //public void TestPostMethod()
        //{
        //    _testMusicController.PostMusicRecord(_testMusic);
        //    Assert.AreEqual(8, _testMusic.Id);
        //}

        //[TestMethod()]
        //public void TestDeleteMethod()
        //{

        //    int musicCount = _testMusicController.GetInMemoryMusicRecords().Result.Value.Count();
        //    int expectedMusicCount = musicCount + 1;

        //    MusicRecords mr1 = new MusicRecords(200, "DeleteTest", "DeleteTest", "DeleteTest", "DeleteTest", 200, 2020);
        //    _testMusicController.PostMusicRecord(mr1);

        //    Assert.AreEqual(_testMusicController.GetInMemoryMusicRecords().Result.Value.Count(), expectedMusicCount);

        //    int expectedMusicCountAfter = _testMusicController.GetInMemoryMusicRecords().Result.Value.Count() - 1;
        //    _testMusicController.DeleteMusicRecord(200);
        //    Assert.AreEqual(_testMusicController.GetInMemoryMusicRecords().Result.Value.Count(), expectedMusicCountAfter);

        //    //Assert.AreEqual(200, mr1.Id);
        //}

        //[TestMethod()]
        //public void TestPutMethod()
        //{


        //    MusicRecords mr1 = new MusicRecords(500, "PutTest", "PutTest", "PutTest", "PutTest", 200, 2020);
        //    _testMusicController.PostMusicRecord(mr1);

        //    //_testMusicController.Put(500, mr1);
        //    _testMusicController.PutMusicRecord(500, new MusicRecords(500, "PutTestAfter", "PutTestAfter", "PutTestAfter", "PutTestAfter", 300, 2021));

        //    Assert.AreEqual("PutTestAfter", mr1.Title);


        //}
    }
}