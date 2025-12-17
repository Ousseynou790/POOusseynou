namespace P3ImplementClasses;

public class BankAccount
{
    public BankCustomer Customer { get; set; }
    public decimal Balance { get; private set; }

    public BankAccount(BankCustomer customer, decimal balance)
    {
        Customer = customer;
        Balance = balance;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
    }
}
