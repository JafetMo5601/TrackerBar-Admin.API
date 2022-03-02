using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace tracker_bar_admin_api.DataModels
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
