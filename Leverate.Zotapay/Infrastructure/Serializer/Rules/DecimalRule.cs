using System;
using System.Reflection;

namespace Leverate.Zotapay.Infrastructure.Serializer.Rules
{
    internal class DecimalRule : IDeserializationRule
    {
        public bool IsSupported(PropertyInfo property)
        {
            return property.PropertyType == typeof(decimal);
        }

        public void DeserializeProperty<T>(T instance, PropertyInfo property, string value)
        {
            if (!IsSupported(property))
            {
                throw new NotSupportedException("Property value cannot be deserialized");
            }

            decimal val;
            if (!decimal.TryParse(value, out val))
            {
                throw new InvalidCastException("Property value cannot be casted to it's type");
            }

            property.SetValue(instance, val);
        }
    }
}