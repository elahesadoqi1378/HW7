
using ConsoleApp17.Entities;

namespace ConsoleApp17.Data
{
    public static class Storage
    {
        public static List<Customer> Custumers = new List<Customer>();

        public static List<Product> Products = new List<Product>();
        public static Customer OnlineUser { get; set; } // online user new nmishe
        

        static Storage()
        {
            Custumers.Add(new Customer()
            { Id = 1, 
              UserName = "ela",
              Password = "1234",
              Address = "tehran" });

            Custumers.Add(new Customer()
            {
                Id = 2,
                UserName="amir",
                Password = "1234",
                Address="tehran" });



            var products = new List<Product>()
            {
                new Product() { Id = 1 ,Name="ball", Category = Category.Sports,Color="white",Price=20},
                new Product() { Id = 2 ,Name="skirt", Category = Category.Clothing,Color="black",Price=40},
                new Product() { Id = 3 ,Name="lipgloss", Category = Category.Cosmetics,Color="brown",Price=10}
            };
            Products.AddRange(products);

            
        }


    }
}
