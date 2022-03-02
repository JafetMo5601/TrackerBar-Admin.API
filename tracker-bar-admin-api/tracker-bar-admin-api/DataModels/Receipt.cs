using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.DataModels
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public User User { get; set; }
        public virtual ReceiptDetail Detail { get; set; }
    }
}
