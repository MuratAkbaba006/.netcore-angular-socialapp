namespace ServerApp.Models
{
    public class Product
    {
        public int Productid { get; set; }
        public string Name { get; set; }

        public decimal price { get; set; }

        public bool isActive { get; set; }

        public string Secret {get;set;}
    }
}