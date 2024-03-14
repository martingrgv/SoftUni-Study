namespace MoneyTransaction;

public class BankAccount
{
    private int accountNumber;

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
    
    public int AccountNumber
    {
        get { return accountNumber; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Account number cannot be negative!");
            }

            accountNumber = value;
        }
    }
    
    public double Balance { get; set; }

    public void Deposit(double sum)
    {
        Balance += sum;
    }

    public void Withdraw(double sum)
    {
        if (sum > Balance)
        {
            throw new ArgumentException("Insufficient balance!");
        }
        
        Balance -= sum;
    }
}