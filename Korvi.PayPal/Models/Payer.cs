using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class Payer
    {
        public string payment_method { get; set; } = "paypal";

        public PayerInfo payer_info { get; set; }
    }
}
