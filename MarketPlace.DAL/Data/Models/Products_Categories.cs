namespace MarketPlace.DAL
{
    public class Products_Categories
    {
        #region Attributes
        public int Product_Id { get; set; }
        public int Category_Id { get; set; }
        #endregion

        #region Nav.Properties
        public Categories? Category { get; set; }
        public Products? Product { get; set; }
        #endregion
    }
}
