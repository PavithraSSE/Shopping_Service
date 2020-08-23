using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingDao
{
    public class Item
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
