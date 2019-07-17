using System;
using System.Collections.Generic;
using System.Text;

namespace SvetulkaApp.Data.Models
{
    public class Review
    {
        public int Id { get; set; }

        public double Rating { get; set; }

        public string Comment { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
