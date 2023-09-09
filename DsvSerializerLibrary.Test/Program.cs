using DsvSerializerLibrary.Core;
using DsvSerializerLibrary.Test;

var person = new Person
{
    FirstName = "Andrey",
    LastName = "Starinin",
    Patronimyc = "Nikolaevich",
    DateOfBirth = new DateTime(1986, 2, 18)
};

var dsv = DsvSerializer.Serialization(person, '|');
Console.WriteLine(dsv);