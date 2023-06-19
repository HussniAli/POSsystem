namespace POS.Entity
{
    public class SalesM
    {
        public int Id { get; set; }
        public DateOnly SalesDate {get;set;}
        public int SalesNumber {get;set;}
        public double SubTotal {get;set;}
        public double Total {get;set;}
        public string CustomerName {get;set;}
        public double Tax {get;set;}
        public bool Status {get;set;}
    }
}