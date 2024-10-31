

namespace ConsoleApp17.Entities
{
    public class ShoppingList
    {
        public  int  Id { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public double FinalPrice { get; set; }


        public void CalculateFinalPrice()
        {
            FinalPrice = 0;
            foreach (var product in Products)
            {
                FinalPrice += product.Price * product.Count;
            }
        }
    }

}
