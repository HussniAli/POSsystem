using System.ComponentModel.DataAnnotations;

namespace POS.Models
{
    public class SubCatagoryVM
    {
    
        public int Id {get;set;}
        
        public string Name {get;set;}

        public int ItemId {get;set;}
         public Item item {get;set;}
    }
}