using Gtk;
using System;
using BankLibrary;

namespace BankApplication
{
    public class OpenAccount
    {
        
        [Builder.Object]
        private TextBuffer textbuffer1;
        
        private Bank<Account> bank;
        private double sum;
        AccountType accountType = AccountType.Ordinary;
        
        public OpenAccount(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/OpenAccount.glade");
            Gui.Autoconnect(this);
            Gtk.Application.Run();
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            sum = Convert.ToDouble(textbuffer1.Text);
            bank.Open(accountType,
                sum,
                AddSumHandler,  
                WithdrawSumHandler, 
                (o, e) => Console.WriteLine(e.Message), 
                CloseAccountHandler, 
                OpenAccountHandler); 
        }
        
        protected void RadioButton1(object sender, EventArgs a)
        {
            accountType = AccountType.Ordinary;
        }
        
        protected void RadioButton2(object sender, EventArgs a)
        {
            accountType = AccountType.Deposit;
        }
        
        private static void OpenAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
            if (e.Sum > 0)
                Console.WriteLine("Идем тратить деньги");
        }
        
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}