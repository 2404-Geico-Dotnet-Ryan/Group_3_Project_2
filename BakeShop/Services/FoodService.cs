// //Place to keep functionality (starting off with 1:1 since movie app only has one model):
class FoodService
{
    FoodRepo fr;
    //FoodService fs = new();
    public FoodService(FoodRepo fr)
    {
        this.fr = fr;
    }

    //Add to Cart
    public Food AddToCart(Food p)
    {


        return p;
    }
    public List<Food> ViewMenu() //Customer
    {
        //get all baked goods:
        List<Food> inventory = fr.ViewAll();

        //empty list for available:
        List<Food> availableItems = new();
        foreach (Food f in inventory)
        {
            if (f.InStock)
            { availableItems.Add(f); }
        }
        //return UPDATED/NEW list:
        return inventory;
    }


    public Food? BuyItem(Food p) //p is the bake item we want to mark in/out stock
    {
        //Check we have
        if (!p.InStock)
        {
            Console.WriteLine("So sorry, we do not have that available.");
            return null;
        }
        p.InStock = false;
        fr.UpdateItem(p);
        return p;
    }

    public List<Food> ViewLast(User u)
    {
        List<Food> allFood = fr.ViewAll();
        List<Food> userPurchase = new();
        foreach (Food f in allFood)
        {
            if (f.User == u)
            {
                userPurchase.Add(f);
            }
        }
        return userPurchase;
    }

    public Food? ViewItem(int id)
    {
        return fr.ViewItem(id);
    }
}