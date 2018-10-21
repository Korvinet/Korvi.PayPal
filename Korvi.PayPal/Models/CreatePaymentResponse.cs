using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class CreatePaymentResponse
    {
        public string id { get; set; }

        public string intent { get; set; }

        public string state { get; set; }
    }
}
