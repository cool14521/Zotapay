using System;

namespace Leverate.Zotapay.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal class FormParameterAttribute : Attribute
    {
        internal FormParameterAttribute(string name)
        {
            this.Name = name;
        }

        internal string Name { get; private set; }
    }
}
