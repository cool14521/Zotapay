using AutoMapper;
using Leverate.Zotapay.Contract;

namespace ZotapayTest.Models
{
    public static class TypeConverter
    {
        public static PaymentModel ToModel(this ReturnCallbackParameters callbackParameters)
        {
            return Mapper.Map<ReturnCallbackParameters, PaymentModel>(callbackParameters);
        }
    }
}