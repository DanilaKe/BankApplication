namespace BankLibrary
{
    public class DemandAccount : Account
    {
        public DemandAccount(double sum, int percentage) : base(sum, percentage)
        {
        }

        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs($"A new demand account is opened. Id : {id}",this._sum));
        }
    }
}