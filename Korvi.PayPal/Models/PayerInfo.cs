using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class PayerInfo
    {
        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string payer_id { get; set; }
    }
}
