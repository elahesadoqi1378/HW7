
using ConsoleApp17.Entities;

namespace ConsoleApp17
{
    public class Customer
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address  { get; set; }
        public ShoppingList shoppinglist { get; set; } = new ShoppingList();
        public List<ShoppingList> PreviousPurchases { get; set; } = new List<ShoppingList>();

    }
}
