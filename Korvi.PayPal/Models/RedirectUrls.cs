using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class RedirectUrls
    {
        public string return_url { get; set; }

        public string cancel_url { get; set; }
    }
}
