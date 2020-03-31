using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DR_Music_Collection
{
    public class MusicRecordsDBContext : DbContext
    {
        public MusicRecordsDBContext(DbContextOptions<MusicRecordsDBContext> options ) : base(options)
        {
            
        }

        public DbSet<MusicRecords> InMemoryMusicRecords { get; set; }
    }
}
