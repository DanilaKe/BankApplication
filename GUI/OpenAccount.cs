using Gtk;
using System;
using BankLibrary;

namespace BankApplication
{
    public class OpenAccount
    {
        
        [Builder.Object] private Entry Entry1;
        [Builder.Object] private ApplicationWindow ApplicationWindow1;

        private Bank<Account> bank;
        private double sum;
        AccountType accountType = AccountType.Ordinary;

        public static DialogWindow dialogWindow { get; set; }

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
        
        protected void ButtonOpen(object sender, EventArgs a)
        {
            try
            {
                sum = Convert.ToDouble(Entry1.Text);
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
        
        protected void ButtonExit(object sender, EventArgs a)
        {
            ApplicationWindow1.Visible = false;
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
            if(dialogWindow == null)
                dialogWindow = new DialogWindow(e);
            else
                dialogWindow.VisibleWindow(e);
        }
        
        private static void AddSumHandler(object sender, AccountEventArgs e)
        {
            if(dialogWindow == null)
                dialogWindow = new DialogWindow(e);
            else
                dialogWindow.VisibleWindow(e);
        }
        
        private static void WithdrawSumHandler(object sender, AccountEventArgs e)
        {
            if(dialogWindow == null)
                dialogWindow = new DialogWindow(e);
            else
                dialogWindow.VisibleWindow(e);
        }
        
        private static void CloseAccountHandler(object sender, AccountEventArgs e)
        {
            if(dialogWindow == null)
                dialogWindow = new DialogWindow(e);
            else
                dialogWindow.VisibleWindow(e);
        }
        
        private static void TransferHandler(object sender, AccountEventArgs e)
        {
            if(dialogWindow == null)
                dialogWindow = new DialogWindow(e);
            else
                dialogWindow.VisibleWindow(e);
        }

        public void VisibleWindow()
        {
            ApplicationWindow1.Visible = true;
        }
    }
}