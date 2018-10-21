using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class Amount
    {
        public string total { get; set; }

        public string currency { get; set; } = "MXN";

        public AmountDetails details { get; set; }
    }
}
