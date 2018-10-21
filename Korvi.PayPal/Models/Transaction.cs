using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class Transaction
    {
        public Amount amount { get; set; }

        public string description { get; set; }

        public string note_to_payee { get; set; }

        public string custom { get; set; }

        public string invoice_number { get; set; }
    }
}
