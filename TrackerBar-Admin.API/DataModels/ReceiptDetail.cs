using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerBar_Admin.API.DataModels
{
    public class ReceiptDetail
    {
        [ForeignKey("Receipt")]
        public int ReceiptDetailId { get; set; }
        public int TableNumber { get; set; }
        public float SubtotalPrice { get; set; }
        public int PeopleQty { get; set; }
        public float Fees { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
