namespace BankLibrary
{
    public interface IAccount
    {
        void Put(double sum);
        void Withdraw(double sum);
    }
}