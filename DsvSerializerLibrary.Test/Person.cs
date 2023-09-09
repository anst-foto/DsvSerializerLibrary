using DsvSerializerLibrary.Core;

namespace DsvSerializerLibrary.Test;

public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Patronimyc { get; init; }

    [NotSerialization(true)] public string FullName => $"{LastName} {FirstName} {Patronimyc}";

    public DateTime DateOfBirth { get; set; }

    [NotSerialization]
    public int Age
    {
        get
        {
            var now = DateTime.Now;
            var age = now.Year - DateOfBirth.Year;
            if (now.Month < DateOfBirth.Month || (now.Month == DateOfBirth.Month && now.Day < DateOfBirth.Day))
                age--;

            return age;
        }
    }
}