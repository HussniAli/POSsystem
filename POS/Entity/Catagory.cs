using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace POS.Entity
{
    [Table("catagory")]
    public class Catagory
    {
        [KeyAttribute]
        [Column( Order=0)]
        public int catId {get;set;}
        [Required]
        
        public string Name {get;set;}
        [MinLength(3)]
        [StringLength(6)]
        public SubCatagory SubCatagory {get;set;}
        public int SubCatagoryId {get;set;}
        // public List<SubCatagory> subCatagories{get;set;}
        [NotMapped]
        public string Email {get;set;}
 

    }
}