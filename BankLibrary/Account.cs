using System;
using System.Dynamic;
using System.Numerics;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        protected internal event AccountStateHandler Withdrawed;
        protected internal event AccountStateHandler Added;
        protected internal event AccountStateHandler Opened;
        protected internal event AccountStateHandler Closed;
        protected internal event AccountStateHandler Calculated;
        protected internal event AccountStateHandler Transfered;
        protected internal event AccountStateHandler Viewed;

        protected uint _id ;
        protected int id;
        static uint counter;
        protected double _sum;
        protected int _percentage;
        protected uint _counterOfTheDays;

        public double CurrentSum => _sum;
        public int Percentage => _percentage;
        public int Id => id;
        public uint Day => _counterOfTheDays;
        public string Info { get; set; }

        public Account(double sum, int percentage)
        {
            _sum = sum;
            _percentage = percentage;                  
            _id=++counter;
            id = Math.Abs(GetHashCode());
        }

        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if ((handler != null) && (e != null))
                handler(this, e);
        }

        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e,Opened);
        }

        protected virtual void OnWithdrawend(AccountEventArgs e)
        {
            CallEvent(e,Withdrawed);
        }
        
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e,Added);
        }
        
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        
        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }
        
        protected virtual void OnTransfer(AccountEventArgs e)
        {
            CallEvent(e, Transfered);
        }
        
        protected virtual void OnViewed(AccountEventArgs e)
        {
            CallEvent(e, Viewed);
        }

        public virtual void Put(double sum)
        {
            this._sum += sum;
            OnAdded(new AccountEventArgs($"The account received $ {sum}", sum));
        }
        
        public virtual void Transfer(double sum)
        {
            if (sum <= this._sum)
            {
                OnTransfer(new AccountEventArgs($"{sum} $ withdrawn from account number {id}",sum)); 
            }
            else
                OnTransfer(new AccountEventArgs($"Not enough money on account number {id}",0));
        }

        public abstract void View();

        public virtual void Withdraw(double sum)
        {
            
            if (sum <= this._sum)
            {
                _sum -= sum;
                OnWithdrawend(new AccountEventArgs($"{sum} $ withdrawn from account number {id}",sum)); 
            }
            else
                OnWithdrawend(new AccountEventArgs($"Not enough money on account number {id}",0));
        }

        protected internal abstract void Open();

        protected internal virtual void Close()
        {
            OnClosed(new AccountEventArgs($"Account {id} is closed. Total amount: {this._sum}", this._sum));
        }

        protected internal void IncrementDays()
        {
            _counterOfTheDays++;
        }
        
        protected internal virtual void Calculate()
        {
            var increment = _sum * _percentage / 100;
            _sum = _sum + increment;
            OnCalculated(new AccountEventArgs($"Interest accrued in the amount of: {increment}", increment));
        }
    }
}