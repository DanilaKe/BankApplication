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

        public override void View()
        {
            Info = $"Demand account id: {id}\n" +
                   $"Account counter : {Id}\n" +
                   $"Current Sum : {CurrentSum}\n" +
                   $"Percentage : {Percentage} %\n" +
                   $"Days have passed since the account was opened : {_counterOfTheDays}\n";
        }
    }
}