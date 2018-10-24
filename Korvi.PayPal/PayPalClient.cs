using Korvi.PayPal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Korvi.PayPal
{
    public class PayPalClient
    {
        const string SANDBOX_URL = "https://api.sandbox.paypal.com";
        const string URL = "https://api.paypal.com";

        bool _isSandbox;
        string _client;
        string _secret;
        AccesToken _accessToken = null;
        DateTime _accessTokenRequested = DateTime.MinValue;

        private string API_URL
        {
            get { return _isSandbox ? SANDBOX_URL : URL; }
        }

        public PayPalClient(bool isSandbox, string client, string secret)
        {
            _isSandbox = isSandbox;
            _client = client;
            _secret = secret;
        }

        public void Authenticate()
        {
            if (_accessToken != null && _accessTokenRequested.AddSeconds(_accessToken.expires_in) < DateTime.Now)
                return;

            string url = $"{API_URL}/v1/oauth2/token";
            _accessTokenRequested = DateTime.Now;

            string payload = "grant_type=client_credentials";
            byte[] content = Encoding.UTF8.GetBytes(payload);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = content.Length;
            request.Method = "POST";
            byte[] bytes = Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _client, _secret));
            string encoded = Convert.ToBase64String(bytes);
            request.Headers.Add("Authorization", $"Basic {encoded}");

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(content, 0, content.Length);
            reqStream.Close();

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();

            _accessToken = JsonConvert.DeserializeObject<AccesToken>(responseFromServer);
        }

        public PaymentResponse CreatePayment(CreatePaymentRequest payment)
        {
            Authenticate();
            string url = $"{API_URL}/v1/payments/payment";
            return Post<PaymentResponse>(url, payment);
        }

        public PaymentResponse ExecutePayment(string paymentId, string payerId)
        {
            Authenticate();
            string url = $"{API_URL}/v1/payments/payment/{paymentId}/execute";
            var body = new { payer_id = payerId };
            return Post<PaymentResponse>(url, body);
        }

        #region Private methods 

        private T Post<T>(string url, object data)
        {
            HttpWebResponse response = AuthenticatedPost(url, data);
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            T result = JsonConvert.DeserializeObject<T>(responseString);
            return result;
        }

        private HttpWebResponse AuthenticatedPost(string url, object data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "POST";
            request.Headers.Add("Authorization", $"Bearer {_accessToken.access_token}");

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            string parsedContent = JsonConvert.SerializeObject(data, settings);
            byte[] bytes = Encoding.UTF8.GetBytes(parsedContent);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();

            return (HttpWebResponse)request.GetResponse();
        }

        #endregion
    }
}
