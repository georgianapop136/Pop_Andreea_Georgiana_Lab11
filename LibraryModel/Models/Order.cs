using System.ComponentModel.DataAnnotations.Schema;

namespace Pop_Andreea_Georgiana_Lab2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int BookID { get; set; }
        public DateTime OrderDate { get; set; }


        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("BookID")]
        public Book Book { get; set; }

    }
}
