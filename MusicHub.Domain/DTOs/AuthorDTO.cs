using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data;

namespace MusicHub.Domain.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<SongDTO> Songs { get; set; }

        public static AuthorDTO FromEntity(Author author)
        {
            return new AuthorDTO
            {
                Id = author.Id,
                FullName = author.FullName,
                Songs = author.Songs.Select(x => SongDTO.FromEntity(x)).ToList()
            };

    }
    }
}
