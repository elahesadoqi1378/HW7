

using ConsoleApp17.Data;
using ConsoleApp17.Entities;

namespace ConsoleApp17
{
    public class UserServices
    {
        public bool Login(string username, string password)
        {
            foreach (var customer in Storage.Custumers)
            {
                if (customer.UserName == username && customer.Password == password && customer != null)

                {
                    //Storage.OnlineUser = customer;
                    Console.WriteLine("Login was successful");
                    return true;
                }
            }
            Console.WriteLine("Invalid username or password ");
            return false;

        }

        public void Register(int id, string username, string password)
        {
            foreach (var customer in Storage.Custumers)
            {
                if (customer.UserName == username )
                {
                    Console.WriteLine("Registration was not successful(because your repeated username !)");
                    return;

                }

            }
            if (!IsValidPassword(password))
            {
                Console.WriteLine("incorrect password! plz try again");
                return;
            }
            Storage.Custumers.Add(new Customer() { Id = id, UserName = username, Password = password });

            Console.WriteLine("Registration was successful");

        }

        public void ProductSelection(int id, int count)
        {
            foreach (var p in Storage.Products)
            {
                if (p.Id == id)
                {
                    if (p.Quantity >= count)
                    {

                        ////ezafe krdne mahsol be sabade khrid
                        p.Count = count;
                        Storage.OnlineUser.shoppinglist.Products.Add(p);
                        //p.Addedtolist = true;
                        p.Quantity -= count;
                        Console.WriteLine("The selected product has been added to the shopping list at " + DateTime.Now);
                        return;
                    }


                }

            }
            Console.WriteLine("The selected product is not available or the ID is not correct");
            return;

        }

        //public void DeleteProductFromCart(int id, int newcount)
        //{

        //    foreach (var p in Storage.Products)
        //    {
        //        if (p.Id == id && p.Count >= newcount && p.Addedtolist)
        //        {
        //            Storage.OnlineUser.shoppinglist.Products.Remove(p);
        //            p.Quantity += newcount;
        //            p.Count -= newcount;
        //            if (p.Count == 0)
        //            {
        //                p.Addedtolist = false;
        //            }
        //            Console.WriteLine("The selected product has been removed from shopping list at" + DateTime.Now);
        //            return;

        //        }

        //    }
        //    Console.WriteLine("The selected product is not available or the ID is not correct");
        //    return;
        //}
      
         public void RemoveProductFromCart(int id, int count)
        {
            foreach (var product in Storage.OnlineUser.shoppinglist.Products)
            {
                if (product.Id == id)
                {
                    if (product.Count > count)
                    {
                        product.Count -= count; 
                        Console.WriteLine($"Removed {count} of {product.Name}s from the shopping cart.");
                        return;
                    }
                    else if (product.Count == count)
                    {
                        Storage.OnlineUser.shoppinglist.Products.Remove(product); 
                        Console.WriteLine($"Removed all {product.Name}s from the shopping cart.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Cannot remove more than {product.Count} of {product.Name} from the shopping cart.");
                        return;
                    }
                }
            }
            Console.WriteLine("The selected product is not in the shopping cart.");
        }

        public void CompletePurchase()
        {

            if (Storage.OnlineUser.shoppinglist.Products.Count > 0)
            {
                Storage.OnlineUser.shoppinglist.CalculateFinalPrice();
                Storage.OnlineUser.PreviousPurchases.Add(Storage.OnlineUser.shoppinglist);
                Console.WriteLine("Purchase completed successfully!");
                Console.WriteLine($"Final Price: {Storage.OnlineUser.shoppinglist.FinalPrice}");
                Storage.OnlineUser.shoppinglist = new ShoppingList(); //khali krdne shoppinglist
            }
            else
            {
                Console.WriteLine("Your shopping cart is empty.");
            }


        }

        public void ViewPreviousPurchases()
        {

            if (Storage.OnlineUser.PreviousPurchases.Count == 0)
            {
                Console.WriteLine("No previous purchases found.");
                return;
            }

            foreach (var buy in Storage.OnlineUser.PreviousPurchases)
            {
                Console.WriteLine("list of Previous Purchases:");
                foreach (var product in buy.Products)
                {
                    Console.WriteLine($"Product: {product.Name}, Quantity: {product.Count}, Price: {product.Price * product.Count}");
                }
                Console.WriteLine($"Final Price: {buy.FinalPrice}");
            }
        }

        public void ProductsList()
        {
            foreach (var p in Storage.Products)
            {
                Console.WriteLine(p.Id + "_" + p.Name + "_" + p.Price + " Availabe Quentity:" + p.Quantity);
            }
            Console.WriteLine("==========================================");


        }

        public bool IsValidPassword(string password)
        {
            bool IncludeUpperCase = false, IncludeLowerCase = false, IncludeNumber = false, IncludeSpecialChar = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) IncludeUpperCase = true;
                else if (char.IsLower(c)) IncludeLowerCase = true;
                else if (char.IsDigit(c)) IncludeNumber = true;
                else if (!char.IsLetterOrDigit(c)) IncludeSpecialChar = true;
            }
            return IncludeUpperCase && IncludeLowerCase && IncludeNumber && IncludeSpecialChar;


        }

        
    }
}


