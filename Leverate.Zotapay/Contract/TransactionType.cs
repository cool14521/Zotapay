using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public enum TransactionType
    {
        [FormParameter("sale")]
        Sale,

        [FormParameter("reversal")]
        Reversal,

        [FormParameter("chargeback")]
        Chargeback
    }
}