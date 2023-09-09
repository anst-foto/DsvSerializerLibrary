namespace DsvSerializerLibrary.Core;

public class NotSerializationAttribute : Attribute
{
    public bool IsSerialization { get; init; }

    public NotSerializationAttribute(bool isSerialization)
    {
        IsSerialization = isSerialization;
    }

    public NotSerializationAttribute()
    {
        IsSerialization = true;
    }
}