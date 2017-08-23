using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data;

namespace MusicHub.Domain.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string NameAndDuration { get; set; }
        
        public static SongDTO FromEntity (Song song)
        {
            return new SongDTO
            {
                Id = song.Id,
                NameAndDuration = $"{song.Name} {song.Duration.Value.Hours} hour(s) {song.Duration.Value.Minutes} minute(s) {song.Duration.Value.Seconds} second(s)"
            };
        }
    }
}
