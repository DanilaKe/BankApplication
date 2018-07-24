using Gtk;
using System;
using  BankLibrary;

namespace BankApplication
{
    class MainWindow 
    {
        [Builder.Object]
        private TextBuffer textbuffer1;
        static Bank<Account> bank = new Bank<Account>("ЮнитБанк");
        
        public MainWindow() 
        {
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/MainWindow.glade");
                Gui.Autoconnect(this);
                Gtk.Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

       
        protected void ButtonOpenClicked(object sender, EventArgs a)
        {
            OpenAccount();
        }
        
        protected void ButtonPutClicked(object sender, EventArgs a)
        {
            Put();
        }
        
        protected void ButtonWithdrawClicked(object sender, EventArgs a)
        {
            Withdraw();
        }
        
        protected void ButtonCloseClicked(object sender, EventArgs a)
        {
            CloseAccount();
        }
        
        protected void ButtonNextDayClicked(object sender, EventArgs a)
        {
            bank.CalculatePercentage();
        }
        
        protected void ButtonView(object sender, EventArgs a)
        {
            ViewWindow();
        }
        
        protected void ButtonTransferClicked(object sender, EventArgs a)
        {
            Transfer();
        }
        
        protected void ButtonExitClicked(object sender, EventArgs a)
        {
            Gtk.Application.Quit();
        }
        
        private static void OpenAccount()
        {
            new OpenAccount(bank);
        }
 
        private static void Withdraw()
        {
            new Withdraw(bank);
        }
 
        private static void Put()
        {
            new Put(bank);
        }
        
        private static void Transfer()
        {
            new Transfer(bank);
        }
 
        private static void CloseAccount()
        {
            new CloseAccount(bank);
        }
        
        private static void ViewWindow()
        {
            new View(bank);
        }
    }
}