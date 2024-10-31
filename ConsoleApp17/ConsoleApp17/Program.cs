using ConsoleApp17;
using ConsoleApp17.Data;
using ConsoleApp17.Entities;
UserServices userServices = new UserServices();
Console.WriteLine("============Welcome to Electronic_Store========");

int Choice;
do
{
    Console.WriteLine("please select one of this items");
    Console.WriteLine("1.Register");
    Console.WriteLine("2.Login");
    Console.WriteLine("3.Exit");
    Choice = int.Parse(Console.ReadLine());
    if (Choice == 1 && Storage.OnlineUser == null)
    {
        Console.WriteLine("enter your Id:");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("enter your Username:");
        string username = Console.ReadLine();
        Console.WriteLine("enter your password");
        string password = Console.ReadLine();
        userServices.Register(id, username, password);
    }
    else if (Choice == 2)
    {
        if (LoginUser())
        {
            UserMenu();
        }

    }
} while (Choice != 3);

    bool LoginUser()
    {
    Console.Write("Enter username: ");
    string username = Console.ReadLine();
    Console.Write("Enter password: ");
    string password = Console.ReadLine();

    if (userServices.Login(username, password))
    {

        foreach (var customer in Storage.Custumers)
        {
            if (customer?.UserName == username)
            {
                Storage.OnlineUser = customer;
                return true;
            }
        }
        return true;
    }
    return false;
}
void UserMenu()
{
    string input;
    do
    {
        Console.WriteLine("Shopping Menu:");
        Console.WriteLine("1.View all products List");
        Console.WriteLine("2.Add a product to your shoppinglist");
        Console.WriteLine("3.remove a product from ypur shoppinglist");
        Console.WriteLine("4.Complete Purchase");
        Console.WriteLine("5.view privious purchases");
        Console.WriteLine("6. Logout");
        input = Console.ReadLine();
        if (input == "1")
        {
            userServices.ProductsList();
        }
        if (input == "2")
        {
            Console.WriteLine("enter id of chosen product");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the count of product you want");
            int count = int.Parse(Console.ReadLine());
            userServices.ProductSelection(id, count);
            //Console.WriteLine("Do you want to continue?(y/n)");
            //string option = Console.ReadLine();
            //if (option == "y")
            //{
            //    continue;
            //}
            //else if(option == "n")
            //{
            //    break;
            //}


        }
        if (input == "3")
        {
            Console.WriteLine("enter id of chosen product");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the count of product you want");
            int count = int.Parse(Console.ReadLine());
            userServices.RemoveProductFromCart(id, count);
        }
        if (input == "4")
        {
            userServices.CompletePurchase();
        }
        if (input == "5")
        {
            userServices.ViewPreviousPurchases();
        }
        if (input == "6")
        {
            break;
        }

    }
    while (Storage.OnlineUser != null);
}




