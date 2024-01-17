using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pop_Andreea_Georgiana_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public int AuthorID { get; set; } // Cheie străină

        [ForeignKey("AuthorID")]
        public Author Author { get; set; } // Proprietate de navigare

        [Column(TypeName = "decimal(6, 2)")]

        public decimal Price { get; set; }

        public List<Author> AvailableAuthors { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<PublishedBook> PublishedBooks { get; set; }

    }
}


