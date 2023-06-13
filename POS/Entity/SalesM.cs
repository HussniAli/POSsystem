namespace POS.Entity
{
    public class SalesM
    {
        public int Id { get; set; }
        public string OrderType {get;set;}
        public int OrderNumber {get;set;}
        public double SubTotal {get;set;}
        public double Total {get;set;}
    }
}