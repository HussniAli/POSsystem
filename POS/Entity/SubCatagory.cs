using POS.Models;

namespace POS.Entity
{
    public class SubCatagory
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int ItemId {get;set;}
        public Item item {get;set;}

        public static implicit operator SubCatagory(SubCatagoryVM v)
        {
            throw new NotImplementedException();
        }


        // public List<Item> items{get;set;}
        // public List<Catagory> catagories{get;set;} 
    }
}