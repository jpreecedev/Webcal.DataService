namespace Connect.Shared
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using Models;

    public class FastQueryHelper
    {
        public static string GetSqlQueryFor<T>(bool includeSchema) where T : Document
        {
            var properties = typeof(T).GetProperties().Where(c => !Attribute.IsDefined(c, typeof(NotMappedAttribute)))
                .Where(c => c.Name != "SerializedData")
                .Where(c => c.GetSetMethod() != null);

            var builder = new StringBuilder();
            builder.Append("SELECT ");

            foreach (var propertyInfo in properties)
            {
                builder.Append(propertyInfo.Name + ", ");
            }

            builder.Append("NULL AS SerializedData");

            var result = builder.ToString();
            result = result + " FROM " + (includeSchema ? "dbo." : "") + "[" + typeof(T).Name + "s]";

            return result;
        }
    }
}