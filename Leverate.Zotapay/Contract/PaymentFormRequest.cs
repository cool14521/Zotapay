using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public abstract class PaymentFormRequest
    {
        protected readonly string m_merchantControl;

        internal PaymentFormRequest(string merchantControl)
        {
            m_merchantControl = merchantControl;
        }

        [Required]
        [FormParameter("client_orderid")]
        public string ClientOrderId { get; set; }

        [Required]
        [FormParameter("order_desc")]
        public string OrderDescription { get; set; }

        [Required]
        [FormParameter("first_name")]
        public string FirstName { get; set; }

        [Required]
        [FormParameter("last_name")]
        public string LastName { get; set; }

        [FormParameter("ssn")]
        public string Ssn { get; set; }

        [FormParameter("birthday")]
        public string Birthday { get; set; }

        [Required]
        [FormParameter("address1")]
        public string Address { get; set; }

        [Required]
        [FormParameter("city")]
        public string City { get; set; }

        [FormParameter("state")]
        public string State { get; set; }

        [Required]
        [FormParameter("zip_code")]
        public string Zip { get; set; }

        [Required]
        [FormParameter("country")]
        public string Country { get; set; }

        [Required]
        [FormParameter("phone")]
        public string Phone { get; set; }

        [FormParameter("cell_phone")]
        public string CellPhone { get; set; }

        [Required]
        [FormParameter("email")]
        public string Email { get; set; }

        [Required]
        [FormParameter("amount")]
        public decimal Amount { get; set; }

        [Required]
        [FormParameter("currency")]
        public string Currency { get; set; }

        [Required]
        [FormParameter("ipaddress")]
        public string IpAddress { get; set; }

        [FormParameter("site_url")]
        public string SiteUrl { get; set; }

        [Required]
        [FormParameter("control")]
        public abstract string Control { get; }

        [Required]
        [FormParameter("redirect_url")]
        public string RedirectUrl { get; set; }

        [FormParameter("server_callback_url")]
        public string ServerCallblackUrl { get; set; }



        protected string EncryptUsingSHA1(string str)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(str));

                Func<StringBuilder, byte, StringBuilder> aggregateFunc = (result, currentByte) => result.Append(currentByte.ToString("X2"));
                var resultBuilder = hash.Aggregate(new StringBuilder(), aggregateFunc);

                return resultBuilder.ToString();
            }
        }
    }
}