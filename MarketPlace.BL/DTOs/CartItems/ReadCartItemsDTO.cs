﻿namespace MarketPlace.BL
{
    public class ReadCartItemsDTO
    {
        public int Id { get; set; }
        public int Product_Id { get; set; }
        public string User_Id { get; set; } = string.Empty;
        public int Quantity { get; set; }

    }
}
