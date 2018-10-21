using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class AmountDetails
    {
        public string subtotal { get; set; }

        public string tax { get; set; }

        public string shipping { get; set; }

        public string handling_fee { get; set; }

        public string shipping_discount { get; set; }

        public string insurance { get; set; }
    }
}
