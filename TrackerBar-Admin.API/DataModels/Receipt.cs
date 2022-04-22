using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }

        public User User { get; set; }
        
        public ReceiptDetail ReeceiptDetail { get; set; }
    }
}
