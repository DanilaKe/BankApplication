using System;
using System.Linq;

namespace BankLibrary
{
    public class Bank<T> where T : Account
    {
        T[] accounts;
             
        string Name { get; }
     
        public Bank(string name)
        {
            this.Name = name;
        }
        
        public void Open(AccountType accountType, double sum, 
            AccountStateHandler addSumHandler, AccountStateHandler withdrawSumHandler,
            AccountStateHandler calculationHandler, AccountStateHandler closeAccountHandler, 
            AccountStateHandler openAccountHandler)
        {
            T newAccount = null;
     
            switch (accountType)
            {
                case AccountType.Ordinary:
                    newAccount = new DemandAccount(sum, 1) as T;
                    break;
                case AccountType.Deposit:
                    newAccount = new DepositAccount(sum, 40) as T;
                    break;
            }
     
            if (newAccount == null)
                throw new Exception("Error creating account");   
            if (accounts == null)
                accounts = new T[] { newAccount };
            else
            {
                var tempAccounts = new T[accounts.Length + 1];
                for (var i = 0; i < accounts.Length; i++)
                    tempAccounts[i] = accounts[i];
                tempAccounts[tempAccounts.Length - 1] = newAccount;
                accounts = tempAccounts;
            }
            newAccount.Added += addSumHandler;
            newAccount.Withdrawed += withdrawSumHandler;
            newAccount.Closed += closeAccountHandler;
            newAccount.Opened += openAccountHandler;
            newAccount.Calculated += calculationHandler;
     
            newAccount.Open();
        }
        
        public void Put(double sum, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Put(sum);
        }
        
        public void Withdraw(double sum, int id)
        {
            T account = FindAccount(id);
            if (account == null)
                throw new Exception("Счет не найден");
            account.Withdraw(sum);
        }
        
        public void Transfer(double sum, int id1, int id2)
        {
            T account1 = FindAccount(id1);
            T account2 = FindAccount(id2);
            if (account1 == null)
                throw new Exception("Счет не найден");
            if (account2 == null)
                throw new Exception("Счет не найден");
            account1.Withdraw(sum);
            account2.Put(sum);
        }
        
        public void Close(int id)
        {
            int index;
            T account = FindAccount(id, out index);
            if (account == null)
                throw new Exception("Счет не найден");
             
            account.Close();
     
            if (accounts.Length <= 1)
                accounts = null;
            else
            {
                var tempAccounts = new T[accounts.Length - 1];
                for (int i = 0, j=0; i < accounts.Length; i++)
                {
                    if (i != index)
                        tempAccounts[j++] = accounts[i];
                }
                accounts = tempAccounts;
            }
        }
     
        public void CalculatePercentage()
        {
            if (accounts == null)
                return;
            foreach (var i in accounts)
            {
                var account = i;
                account.IncrementDays();
                account.Calculate();
            }
        }
     
        public T FindAccount(int id)
        {
            return accounts.FirstOrDefault(i => i.Id == id);
        }
 
        public T FindAccount(int id, out int index)
        {
            for (var i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Id != id) continue;
                index = i;
                return accounts[i];
            }
            index = -1;
            return null;
        }
    }
    
    public enum AccountType
    {
        Ordinary,
        Deposit
    }
}