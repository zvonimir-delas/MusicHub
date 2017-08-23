using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Data;
using MusicHub.Domain.DTOs;
using System.Data.Entity;

namespace MusicHub.Domain
{
    public class AuthorRepository
    {
        public AuthorDTO GetAuthorByName(string fullName)
        {
            using (var context = new MusicHubDb())
            {
                return context.Authors.Include("Songs").Where(x => x.FullName == fullName).ToList().Select(y => AuthorDTO.FromEntity(y)).FirstOrDefault();
            }
        }

        public void AddAuthor(string fullName, string password)
        {
            using (var context = new MusicHubDb())
            {
                context.Authors.Add(new Author()
                {
                    Id = context.Authors.ToList().Count(),
                    FullName = fullName,
                    Password = password
                });

                context.SaveChanges();
            }
        }

        public void DeleteAuthor(string fullName, string password)
        {
            using (var context = new MusicHubDb())
            {
                Author author = context.Authors.Where(x => x.FullName == fullName && x.Password == password).FirstOrDefault();
                context.Entry(author).State = EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
