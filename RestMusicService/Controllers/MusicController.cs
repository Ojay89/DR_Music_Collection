using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DR_Music_Collection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestMusicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private static readonly List<MusicRecords> musicList = new List<MusicRecords>()
        {
            new MusicRecords(1, "Novembervej", "Nik & Jay", "Novembervej", "Nik & Jay Records", 120, 2010),
            new MusicRecords(2, "You're Not There", "Lukas Graham", "Lukas Graham (Blue Album)", "Copenhagen Records", 230, 2015),
            new MusicRecords(3, "Famous", "Kanye West", "The Life of Pablp", "UMG Records", 158, 2016),
            new MusicRecords(4, "Helwa", "Gili", "Helwa the Album", "OO Productions", 176, 2018),
            new MusicRecords(5, "I love you baby", "Frank Sinatra", "Frankie & Friends", "Fankiestein", 148, 1989),
            new MusicRecords(6, "Dance Monkey","Tones and I","Dance Monkey", "Sony Productions", 196, 2020)
        };

        // GET: api/Music
        [HttpGet]
        public IEnumerable<MusicRecords> Get()
        {
            return musicList;
        }

        // GET: api/Music/5
        [HttpGet("{id}", Name = "Get")]
        public MusicRecords Get(int id)
        {
            return musicList.Find(i => i.Id == id);
        }

        // POST: api/Music
        [HttpPost]
        public void Post([FromBody] MusicRecords value)
        {
            musicList.Add(value);
        }

        //// PUT: api/Music/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Music value)
        //{
        //    Music music = Get(id);
        //    if (music != null)
        //    {
        //        music.Id = value.Id;
        //        music.Title = value.Title;
        //        music.Artist = value.Artist;
        //        music.Album = value.Album;
        //        music.Duration = value.Duration;
        //        music.RecordLabel = value.RecordLabel;
        //        music.YearOfPublication = value.YearOfPublication;
        //    }
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    Music music = Get(id);
        //    musicList.Remove(music);
        //}

    }
}
