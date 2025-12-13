using P1CreateClasses;

string firstName = "Tim";
string lastName = "Shao";
string customerIdNumber = "1010101010";

BankCustomer customer1 = new BankCustomer();

firstName = "Lisa";
BankCustomer customer2 = new BankCustomer(firstName, lastName);

firstName = "Sandy";
lastName = "Zoeng";
customerIdNumber = "2020202020";
BankCustomer customer3 = new BankCustomer(firstName, lastName, customerIdNumber);

Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.CustomerId}");
Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.CustomerId}");
Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.CustomerId}");
