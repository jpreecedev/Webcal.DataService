using System;

namespace Connect.Shared
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class FullDocumentTypeAttribute : Attribute
    {
        public FullDocumentTypeAttribute(Type type)
        {
            Type = type.FullName;
        }

        public string Type { get; set; }
    }
}