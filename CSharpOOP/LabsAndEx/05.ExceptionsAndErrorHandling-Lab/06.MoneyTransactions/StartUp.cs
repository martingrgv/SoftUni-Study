namespace MoneyTransaction;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<BankAccount> bankAccounts = GetBankAccounts();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                string command = data[0];
                BankAccount currentAccount = GetAccountByNumber(bankAccounts, int.Parse(data[1]));

                try
                {
                    double sum = double.Parse(data[2]);

                    switch (command)
                    {
                        case "Deposit":
                            currentAccount.Deposit(sum);
                            break;
                        case "Withdraw":
                            currentAccount.Withdraw(sum);
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                    
                    Console.WriteLine($"Account {currentAccount.AccountNumber} has new balance: {currentAccount.Balance:f2}");
                }
                catch (FormatException ex)
                {
                    throw new ArgumentException("Invalid command!");
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Invalid account!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Enter another command");
            }
        }
    }

    private static List<BankAccount> GetBankAccounts()
    {
        List<BankAccount> bankAccounts = new List<BankAccount>();

        try
        {
            string[] accountsData = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var account in accountsData)
            {
                try
                {
                    string[] currentAccountData = account.Split('-', StringSplitOptions.RemoveEmptyEntries);
                    bankAccounts.Add(new BankAccount(int.Parse(currentAccountData[0]), double.Parse(currentAccountData[1])));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid command!");
                }
            }

            return bankAccounts;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid command!");
            return null;
        }

    }

    private static BankAccount GetAccountByNumber(List<BankAccount> bankAccounts, int number)
    {
        BankAccount account = bankAccounts.FirstOrDefault(a => a.AccountNumber == number);

        if (account != null)
        {
            return account;
        }
        
        throw new ArgumentException("Invalid account!");
    }
}