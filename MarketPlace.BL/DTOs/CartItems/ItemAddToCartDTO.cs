﻿namespace MarketPlace.BL
{
    public class ItemAddToCartDTO
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
        public string User_Id { get; set; } = String.Empty;
    }
}
