using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal.Models
{
    public class AccesToken
    {
        public string scope { get; set; }

        public string nonce { get; set; }

        public string access_token { get; set; }

        public string token_type { get; set; }

        public string app_id { get; set; }

        public long expires_in { get; set; }
    }
}
