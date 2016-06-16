using System.Data.Entity;
using ZotapayTest.Models;

namespace ZotapayTest.Data
{
    public class PaymentsContext : DbContext
    {
        public PaymentsContext() : base("PaymentsContext")
        {
        }

        public DbSet<PaymentModel> Payments { get; set; }
    }
}