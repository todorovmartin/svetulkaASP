﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SvetulkaApp.Web.ViewModels.Favorites
{
    public class AllFavoriteViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImageUrl { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
