using System;
using System.Linq;
using System.Reflection;

namespace Leverate.Zotapay.Infrastructure.Serializer.Rules
{
    internal class EnumRule : IDeserializationRule
    {
        public bool IsSupported(PropertyInfo property)
        {
            return property.PropertyType.IsEnum;
        }

        public void DeserializeProperty<T>(T instance, PropertyInfo property, string value)
        {
            if (!IsSupported(property))
            {
                throw new NotSupportedException("Property value cannot be deserialized");
            }

            var enumField = property.PropertyType
                .GetFields()
                .SingleOrDefault(p =>
                {
                    var formParameterAttr = CustomAttributeExtensions.GetCustomAttribute<FormParameterAttribute>((MemberInfo) p);
                    return formParameterAttr != null && formParameterAttr.Name == value;
                });

            if (enumField != null)
            {
                var enumValue = Enum.Parse(property.PropertyType, enumField.Name);
                property.SetValue(instance, enumValue);
            }
        }
    }
}