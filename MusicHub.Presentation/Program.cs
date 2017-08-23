using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicHub.Domain;

namespace MusicHub.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var authorRepository = new AuthorRepository();
            while (true)
            {
                Console.WriteLine("Pick an option\n 1) Access Authors\n 2) Access Songs");

                int optionChosen = int.Parse(Console.ReadLine());

                if (optionChosen == 1)
                {
                    Console.WriteLine("Pick an option\n 1) View songs by an author\n 2) Add an author\n 3) Remove an author");

                    optionChosen = int.Parse(Console.ReadLine());

                    if (optionChosen == 1)
                    {
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        authorRepository.GetAuthorByName(name).Songs.ToList().ForEach(x => Console.WriteLine(x.NameAndDuration)); //TRY CATch
                    }

                    else if (optionChosen == 2)
                    {
                        string name; //does not work if name is defined inside 'do' block
                        do
                        {
                            Console.WriteLine("Name: ");
                            name = Console.ReadLine();
                        }
                        while (authorRepository.GetAuthorByName(name) != null);

                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();

                        authorRepository.AddAuthor(name, password);
                    }

                    else if (optionChosen == 3)
                    {
                        string name; //does not work if name is defined inside 'do' block
                        do
                        {
                            Console.WriteLine("Name: ");
                            name = Console.ReadLine();
                        }
                        while (authorRepository.GetAuthorByName(name) == null);

                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();

                        authorRepository.DeleteAuthor(name, password);
                    }
                }
            }
        }
    }
}