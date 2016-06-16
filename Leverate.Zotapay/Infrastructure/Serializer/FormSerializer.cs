using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using Leverate.Zotapay.Infrastructure.Serializer.Rules;

namespace Leverate.Zotapay.Infrastructure.Serializer
{
    internal class FormSerializer
    {
        private readonly ReadOnlyCollection<IDeserializationRule> m_deserializationRules;

        internal FormSerializer()
        {
            var ruleInterface = typeof (IDeserializationRule);
            var rules = (from type in Assembly.GetAssembly(ruleInterface).GetTypes()
                         where ruleInterface.IsAssignableFrom(type) &&
                                 !type.IsInterface &&
                                 !type.IsAbstract
                         select Activator.CreateInstance(type) as IDeserializationRule).ToList();

            m_deserializationRules = new ReadOnlyCollection<IDeserializationRule>(rules);
        }


        internal string Serialize<T>(T obj)
        {
            var parameters = from property in typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                             let parameterAttr = property.GetCustomAttributes<FormParameterAttribute>().FirstOrDefault()
                             where parameterAttr != null
                             select new KeyValuePair<string, object>(parameterAttr.Name, property.GetValue(obj));
            
            var builder = new StringBuilder();

            using (var enumerator = parameters.GetEnumerator())
            {
                var hasNext = enumerator.MoveNext();
                if (!hasNext)
                {
                    return string.Empty;
                }

                builder.Append("?");

                do
                {
                    builder.AppendFormat("{0}={1:0.00}", enumerator.Current.Key, enumerator.Current.Value);
                    hasNext = enumerator.MoveNext();

                    if (hasNext)
                    {
                        builder.Append("&");
                    }
                } while (hasNext);

                return builder.ToString();
            }
        }

        internal T Deserialize<T>(string formData)
        {
            return (T) this.Deserialize(typeof (T), formData);
        }

        internal object Deserialize(Type modelType, string formData)
        {
            var instance = Activator.CreateInstance(modelType);

            var parameters = (from parameter in formData.Split('&')
                              let parameterInfo = parameter.Split('=')
                              where parameterInfo.Length == 2
                              select new KeyValuePair<string, string>(parameterInfo[0], parameterInfo[1])).ToList();

            if (!parameters.Any())
            {
                return instance;
            }

            foreach (var parameter in parameters)
            {
                var property = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                        .SingleOrDefault(prop =>
                                        {
                                            var parameterAttr = prop.GetCustomAttributes<FormParameterAttribute>().FirstOrDefault();
                                            return parameterAttr != null && parameterAttr.Name == parameter.Key;
                                        });

                if (property != null)
                {
                    this.SetPropertyValue(instance, property, parameter.Value);
                }
            }

            return instance;
        }


        private void SetPropertyValue<T>(T instance, PropertyInfo property, string value)
        {
            var propertyValue = Uri.UnescapeDataString(value).Trim();

            foreach (var rule in m_deserializationRules)
            {
                if (rule.IsSupported(property))
                {
                    rule.DeserializeProperty(instance, property, propertyValue);
                    return;
                }
            }
        }
    }
}
