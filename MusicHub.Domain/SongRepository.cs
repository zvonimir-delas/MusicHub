using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data;

namespace MusicHub.Domain
{
    public class SongRepository
    {
        public void AddNewSong(string name, string duration, Author author)
        {
            using (var context = new MusicHubDb())
            {
                context.Songs.Add(new Song()
                {
                    Id = context.Songs.ToList().Count(),
                    Name = name,
                    Duration = TimeSpan.Parse(duration),
                    Author1 = author
                });

                context.SaveChanges();
            }
        }
    }
}
