using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class PaymentResponse
    {
        public string id { get; set; }

        public string create_time { get; set; }

        public string update_time { get; set; }

        public string intent { get; set; }

        public string state { get; set; }

        public Payer payer { get; set; }

        public List<Transaction> transactions { get; set; } = new List<Transaction>();
    }
}
