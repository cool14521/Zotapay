using System.Collections.Generic;
using System.Data.Entity;
using ZotapayTest.Models;

namespace ZotapayTest.Data
{
    public class PaymentRepository
    {
        private readonly DbContext m_dbContext;

        public PaymentRepository(DbContext dbContext)
        {
            m_dbContext = dbContext;
        }

        public IEnumerable<PaymentModel> Get()
        {
            return m_dbContext.Set<PaymentModel>();
        }

        public void Add(PaymentModel payment)
        {
            m_dbContext.Set<PaymentModel>().Add(payment);
        }

        public void SaveChanges()
        {
            m_dbContext.SaveChanges();
        }
    }
}