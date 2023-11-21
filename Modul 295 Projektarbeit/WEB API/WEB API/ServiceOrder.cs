namespace WEB_API
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; } 
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Priority { get; set; }
        public string ServiceType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
        public string Status { get; set; } = "Offen";
    }
}