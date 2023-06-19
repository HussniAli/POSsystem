namespace POS.Entity
{
    public class Catagory
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public SubCatagory subcatagory {get;set;}
        public int SubCatagoryId {get;set;}
        public List<SubCatagory> subCatagories{get;set;}


    }
}