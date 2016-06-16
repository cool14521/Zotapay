using Leverate.Zotapay.Infrastructure;

namespace Leverate.Zotapay.Contract
{
    public enum PaymentFormResponseType
    {
        [FormParameter("async-form-response")]
        AsyncFormResponse,

        [FormParameter("validation-error")]
        ValidationError,

        [FormParameter("error")]
        Error
    }
}