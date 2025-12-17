using P3ImplementClasses;

BankCustomer customer = new BankCustomer("Tim", "Shao");
BankAccount account = new BankAccount(customer, 1000);

account.Deposit(500);
account.Withdraw(200);

Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
Console.WriteLine($"Balance: {account.Balance}");
