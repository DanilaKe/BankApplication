﻿namespace BankLibrary
{
    public class DepositAccount : Account
    {
        public DepositAccount(double sum, int percentage) : base(sum, percentage)
        {
            _counterOfTheDays++;
        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new deposit account is opened. Id : {id}",this._sum));
        }

        public override void Put(double sum)
        {
            if (_counterOfTheDays % 30 == 0)
                base.Put(sum);
            else
                base.OnAdded(new AccountEventArgs("You can only deposit to your account after a 30-day period", 0));
        }

        public override void Withdraw(double sum)
        {
            if (_counterOfTheDays % 30 == 0)
                base.Withdraw(sum);
            else
                base.OnWithdrawend(new AccountEventArgs("You can withdraw funds only after a 30-day period", 0));
        }

        public override void Transfered(double sum)
        {
            if (_counterOfTheDays % 30 == 0)
                base.Transfered(sum);
            else
                base.OnTransfer(new AccountEventArgs("You can withdraw funds only after a 30-day period", 0));
        }

        protected internal override void Calculate()
        {
            if (_counterOfTheDays % 30 == 0)
                base.Calculate();
        }
        
    }
}