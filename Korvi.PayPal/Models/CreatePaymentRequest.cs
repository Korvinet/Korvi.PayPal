using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class CreatePaymentRequest
    {
        /// <summary>
        /// sale - authorize - order
        /// </summary>
        public string intent { get; set; } = "sale";

        public Payer payer { get; set; } = new Payer();

        public object application_context { get; set; }

        public List<Transaction> transactions { get; set; } = new List<Transaction>();

        /// <summary>
        /// Max: 165 chars
        /// </summary>
        public string note_to_payer { get; set; }

        public RedirectUrls redirect_urls { get; set; }

        public static CreatePaymentRequest CreatePayment()
        {
            return new CreatePaymentRequest() { };
        }

        public void AddTransaction(string description, decimal total, decimal subtotal, decimal tax, 
            decimal handlingFee = 0.0m, decimal shipping = 0.0m, string custom = "")
        {
            var transaction = new Transaction()
            {
                custom = custom,
                description = description,
                note_to_payee = "",
                amount = new Amount()
                {
                    details = new AmountDetails() {
                        subtotal = subtotal.ToString("0.00"),
                        tax = tax.ToString("0.00"),
                        shipping = shipping.ToString("0.00"),
                        handling_fee = handlingFee.ToString("0.00"),
                        insurance = "0.00",
                        shipping_discount = "0.00"
            
                    },
                    total = total.ToString("0.00"),
                }
            };
            transactions.Add(transaction);
        }
    }
}
