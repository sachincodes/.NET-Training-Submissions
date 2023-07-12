﻿namespace Ecommerce.Models
{
    public  class  Laptop :IProduct
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  int  Price { get; set; }
        public bool DiscountApplied { get; set; } = false;

        public int  Discount()
        {
            int d = (this.Price * 5) / 100; ;
            this.Price = this.Price - d;
            return d;
        }


    }
}
