namespace Gims.Core.Domain.Party;

public class Person : Party
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime? DateOfBirth { get; private set; }

    public Person(
        string firstName,
        string lastName,
        ContactInfo contactInfo,
        DateTime? dob = null)
        : base(PartyType.Person, $"{firstName} {lastName}", contactInfo)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
    }

    private Person() { }
}