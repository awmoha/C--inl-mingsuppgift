namespace Bank_Applikation.Models
{
    public class SavingsAccount
    {
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }
        public const decimal InterestRate = 1.0m; // Räntesatsen som konstant
        public const string AccountType = "SavingsAccount";

        public SavingsAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public decimal CalculateInterest()
        {
            return Balance * (InterestRate / 100);
        }

        public string GetAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Balance: {Balance}, Type: {AccountType}, Interest Rate: {InterestRate}%";
        }
    }

}