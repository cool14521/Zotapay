using System;
using System.Reflection;

namespace Leverate.Zotapay.Infrastructure.Serializer.Rules
{
    internal class BoolRule : IDeserializationRule
    {
        public bool IsSupported(PropertyInfo property)
        {
            return property.PropertyType == typeof(bool);
        }

        public void DeserializeProperty<T>(T instance, PropertyInfo property, string value)
        {
            if (!IsSupported(property))
            {
                throw new NotSupportedException("Property value cannot be deserialized");
            }

            property.SetValue(instance, value == "enabled");
        }
    }
}