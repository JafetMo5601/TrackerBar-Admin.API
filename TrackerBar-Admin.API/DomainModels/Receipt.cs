namespace TrackerBar_Admin.API.DomainModels
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public User User { get; set; }
        public virtual ReceiptDetail Detail { get; set; }
    }
}
