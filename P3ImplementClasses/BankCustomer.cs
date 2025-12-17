namespace P3ImplementClasses;

public class BankCustomer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public BankCustomer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
