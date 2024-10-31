namespace ConsoleApp17.Entities
{
    public enum Category
    {
        Clothing = 1,
        Sports = 2,
        Foods = 3,
        Cosmetics = 4

    }
    public class Product
    {
        public Product()
        {
            Quantity = 15;
            Count = 0;
            Datetime = DateTime.Now;
            //Addedtolist = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public  string Color { get; set; }
        public int Quantity { get; set; } 
        public int Count { get; set; } 
        public int Price { get; set; }
        //public bool Addedtolist { get; set; }
        public DateTime Datetime { get; set; }



    }
}
