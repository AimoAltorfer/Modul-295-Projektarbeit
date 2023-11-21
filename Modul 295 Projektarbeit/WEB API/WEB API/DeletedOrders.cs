using WEB_API;
namespace WEB_API
{
    public class DeletedOrder
    {
        public int DeletedOrderID { get; set; }
        public int OriginalServiceOrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Priority { get; set; }
        public string ServiceType { get; set; }
        public string Status { get; set; } = "Gelöscht";
    }
}
