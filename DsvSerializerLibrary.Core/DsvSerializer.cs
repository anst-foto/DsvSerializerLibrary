using System.Text;

namespace DsvSerializerLibrary.Core;

public class DsvSerializer
{
    public static string Serialization(object obj, char delimiter)
    {
        var type = obj.GetType();
        var properties = type.GetProperties();

        var strBuilder = new StringBuilder();
        foreach (var property in properties) //BUG
        {
            var prop = property.GetValue(obj)?.ToString();
            var attributes = property.GetCustomAttributes(typeof(NotSerializationAttribute), true);
            if (attributes.Length == 0)
            {
                strBuilder.Append(prop);
                strBuilder.Append(delimiter);
                
                continue;
            }
            
            var notSerialization = (attributes[0] as NotSerializationAttribute)?.IsSerialization;

            if (notSerialization is null)
            {
                strBuilder.Append(prop);
                strBuilder.Append(delimiter);
                
                continue;
            }

            if (notSerialization == false)
            {
                strBuilder.Append(prop);
                strBuilder.Append(delimiter);
            }
        }

        return strBuilder.ToString();
    }
}