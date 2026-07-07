using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerRegistry
{
    public class Wallet
    {
        public Guid Id { get; }
        public Guid PlayerId { get; }
        public decimal Balance { get; private set; }
        public Currency Currency { get; }
        public bool IsBlocked { get; private set; }

        public Wallet( Guid playerId, Currency currency, decimal initialBalance = 0)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Ballance cannot be negative!");
            }
            Id = Guid.NewGuid();
            PlayerId = playerId;
            Balance = initialBalance;
            Currency = currency;
            IsBlocked = false;
        }

        public void Deposit(decimal amount) {
            if (IsBlocked) {
                throw new InvalidOperationException("Wallet is blocked!");
            }
            if(amount <= 0)
            {
                throw new ArgumentException("Amount must be positive!");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (IsBlocked)
            {
                throw new InvalidOperationException("Wallet is blocked!");
            }
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive!");
            }
            if (Balance - amount < 0) {
                throw new InvalidOperationException("Balance cannot go nagative!");
            }
            Balance -= amount;
        }

        public void ToggleBlock() { 
            IsBlocked = !IsBlocked;
        }

        public override string ToString() =>
        
            $"[Wallet: {Currency}] Balance: {Balance} | Blocked : {IsBlocked}";
    }
}
