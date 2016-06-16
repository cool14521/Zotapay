using AutoMapper;
using Leverate.Zotapay.Contract;
using ZotapayTest.Models;

namespace ZotapayTest
{
    public static class MapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(mapperConfig =>
            {
                mapperConfig.CreateMap<ReturnCallbackParameters, PaymentModel>()
                    .ForMember(p => p.OrderId, options => options.MapFrom(p => p.ClientOrderId))
                    .ForMember(p => p.Status, options => options.MapFrom(p => p.Status.ToString()))
                    .ForMember(p => p.TransactionType, options => options.MapFrom(p => p.TransactionType.ToString()));
            });
        }
    }
}