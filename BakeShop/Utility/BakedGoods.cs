class BakedGoods
{

    public Dictionary<int, Food> bakeryItems;

    public int idCounter = 1;
    // //Constructor to give us menu options to start:
    public BakedGoods()
    {
        Food bakeGood1 = new(idCounter++, "Plain Bagel", 1.49, true, null);
        Food bakeGood2 = new(idCounter++, "Everything Bagel", 1.99, true, null);
        Food bakeGood3 = new(idCounter++, "Cinnamon Raisin Bagel", 2.09, true, null);

        Food bakeGood4 = new(idCounter++, "Chocolate Chip Cookies", 1.50, true, null);
        Food bakeGood5 = new(idCounter++, "Peanut Butter Cookies", 1.50, true, null);
        Food bakeGood6 = new(idCounter++, "Salted Caramel Cookies", 1.50, true, null);

        Food bakeGood7 = new(idCounter++, "Sourdough Bread", 4.87, true, null);
        Food bakeGood8 = new(idCounter++, "Sandwich Bread", 4.87, true, null);
        Food bakeGood9 = new(idCounter++, "Artisan Bread", 4.87, true, null);


        bakeryItems = []; //sets the dictionary to an empty collection, instead of at the top, 
        //moving it into the constructor
        bakeryItems.Add(bakeGood1.Id, bakeGood1);
        bakeryItems.Add(bakeGood2.Id, bakeGood2);
        bakeryItems.Add(bakeGood3.Id, bakeGood3);
        bakeryItems.Add(bakeGood4.Id, bakeGood4);
        bakeryItems.Add(bakeGood5.Id, bakeGood5);
        bakeryItems.Add(bakeGood6.Id, bakeGood6);
        bakeryItems.Add(bakeGood7.Id, bakeGood7);
        bakeryItems.Add(bakeGood8.Id, bakeGood8);
        bakeryItems.Add(bakeGood9.Id, bakeGood9);

    }

}