namespace TrackerBar_Admin.API.DataModels
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public User User { get; set; }
        public ReceiptDetail Detail { get; set; }
    }
}
