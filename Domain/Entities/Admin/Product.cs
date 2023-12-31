﻿using Domain.Entities.Inheritance;

namespace Domain.Entities.Admin
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid IdCategory { get; set; }
        public virtual Category Category { get; set; }
    }
}
