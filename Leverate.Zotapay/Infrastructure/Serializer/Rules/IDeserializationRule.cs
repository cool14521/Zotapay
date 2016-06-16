using System.Reflection;

namespace Leverate.Zotapay.Infrastructure.Serializer.Rules
{
    internal interface IDeserializationRule
    {
        bool IsSupported(PropertyInfo property);
        void DeserializeProperty<T>(T instance, PropertyInfo property, string value);
    }
}
