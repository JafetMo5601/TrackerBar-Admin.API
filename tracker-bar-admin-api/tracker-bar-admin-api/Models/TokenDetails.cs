using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tracker_bar_admin_api.Models
{
    public record TokenDetails
    (
        string Token,
        DateTime Expiration
    );
}
