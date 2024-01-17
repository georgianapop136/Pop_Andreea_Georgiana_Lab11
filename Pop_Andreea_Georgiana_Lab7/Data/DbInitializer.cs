using Microsoft.EntityFrameworkCore;
using Pop_Andreea_Georgiana_Lab2.Models;


namespace Pop_Andreea_Georgiana_Lab2.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new
           LibraryContext(serviceProvider.GetRequiredService
            <DbContextOptions<LibraryContext>>()))
            {
                if (context.Books.Any())
                {
                    return; // BD a fost creata anterior
                }

                var author1 = new Author { FirstName = "Mihail", LastName = "Sadoveanu" };
                var author2 = new Author { FirstName = "George", LastName = "Calinescu" };
                var author3 = new Author { FirstName = "Mircea", LastName = "Eliade" };

                context.Authors.AddRange(author1, author2, author3);

                var book1 = new Book
                {
                    Title = "Baltagul",
                    Author = author1,
                    Price = Decimal.Parse("22")
                };

                var book2 = new Book
                {
                    Title = "Enigma Otiliei",
                    Author = author2,
                    Price = Decimal.Parse("18")
                };

                var book3 = new Book
                {
                    Title = "Maytrei",
                    Author = author3,
                    Price = Decimal.Parse("27")
                };

                context.Books.AddRange(book1, book2, book3);

                var city1 = new City { CityName = "Cluj-Napoca" };
                var city2 = new City { CityName = "Oradea" };

                context.Cities.AddRange(city1);


                var customer1 = new Customer
                {
                    Name = "Popescu Marcela",
                    Adress = "Str. Plopilor, nr. 24",
                    BirthDate = DateTime.Parse("1979-09-01"),
                    City = city1
                };

                var customer2 = new Customer
                {
                    Name = "Mihailescu Cornel",
                    Adress = "Str. Bucuresti, nr.45,ap. 2",
                    BirthDate = DateTime.Parse("1969 - 07 - 08"),
                    City = city2
                };

                context.Customers.AddRange(customer1, customer2);


                context.Orders.AddRange(
               new Order
               {
                   Customer = customer1,
                   Book = book1,
                   OrderDate = DateTime.Parse("2023 - 09 - 09")

               },
                new Order
                {
                    Customer = customer2,
                    Book = book3,
                    OrderDate = DateTime.Parse("2023 - 03 - 06")
                }
                );

                context.SaveChanges();

                var publisher1 = new Publisher { PublisherName = "Humanitas", Adress = "Str. Aviatorilor, nr. 40,Bucuresti" };
                var publisher2 = new Publisher { PublisherName = "Nemira", Adress = "Str. Plopilor, nr. 35,Ploiesti" };
                var publisher3 = new Publisher { PublisherName = "Paralela 45", Adress = "Str. Cascadelor, nr.22, Cluj-Napoca" };

                var publishers = new Publisher[]{publisher1, publisher2, publisher3 };

                foreach (Publisher p in publishers)
                {
                    context.Publishers.Add(p);
                }
                context.SaveChanges();
               
                var books = context.Books;

                var publishedBooks = new PublishedBook[]
                {
                    new PublishedBook
                    {
                        Book = book3,
                        Publisher = publisher1
                    },
                    new PublishedBook
                    {
                        Book = book2,
                        Publisher = publisher1
                    },
                    new PublishedBook
                    {
                        Book = book1,
                        Publisher = publisher2
                    }
                };


                foreach (PublishedBook pb in publishedBooks)
                {
                    context.PublishedBooks.Add(pb);
                }
                context.SaveChanges();



            }
        }
    }
}



