using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public enum PaymentStatus
    {
        [FormParameter("approved")]
        Approved,

        [FormParameter("declined")]
        Declined,

        [FormParameter("error")]
        Error,

        [FormParameter("filtered")]
        Filtered,

        [FormParameter("processing")]
        Processing,

        [FormParameter("unknown")]
        Unknown
    }
}