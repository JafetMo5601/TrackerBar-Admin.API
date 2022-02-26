using System.Collections.Generic;


namespace tracker_bar_admin_api.DataModels
{
    public class ReceiptDetail
    {
        public int ReceiptDetailId { get; set; }
        public int TableNumber { get; set; }
        public float SubtotalPrice { get; set; }
        public int PeopleQty { get; set; }
        public float Fees { get; set; }
        public IList<Receipt> Receipts { get; set; }
    }
}
