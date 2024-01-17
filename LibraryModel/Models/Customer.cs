using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pop_Andreea_Georgiana_Lab2.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public City City { get; set; }

    }
}
