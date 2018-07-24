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
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/OpenAccount.glade");
                Gui.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            try
            {
                sum = Convert.ToDouble(textbuffer1.Text);
                bank.Open(accountType,
                    sum,
                    AddSumHandler,  
                    WithdrawSumHandler, 
                    (o, e) => Console.WriteLine(e.Message), 
                    CloseAccountHandler, 
                    OpenAccountHandler,
                    TransferHandler); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
            new DialogWindow(e);
        }
        
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            new DialogWindow(e);
        }
        
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            new DialogWindow(e);
        }
        
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            new DialogWindow(e);
        }
        
        private static void TransferHandler(object sender, AccountEventArgs e)
        {
            new DialogWindow(e);
        }
    }
}