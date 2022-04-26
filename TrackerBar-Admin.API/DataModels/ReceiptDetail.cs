using System.ComponentModel.DataAnnotations;

namespace TrackerBar_Admin.API.DataModels
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailId { get; set; }
        public int TableNumber { get; set; }
        public float SubtotalPrice { get; set; }
        public int PeopleQty { get; set; }
        public float Fees { get; set; }
        public DateTime boughtAt { get; set; }


        public Restaurant Restaurant { get; set; }

        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
    }
}
