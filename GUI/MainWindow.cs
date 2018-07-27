using Gtk;
using System;
using  BankLibrary;

namespace BankApplication
{
    class MainWindow 
    {
        [Builder.Object] private TextBuffer textbuffer1;
        [Builder.Object] private AboutDialog AboutDialog1;
        [Builder.Object] private ApplicationWindow ApplicationWindow1;
        [Builder.Object] private Dialog Dialog1;
        [Builder.Object] private Entry Entry1;
        
        static Bank<Account> bank;
        string nameBank = "";
        
        public MainWindow()
        {
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/BankName.glade");
                Gui.Autoconnect(this);
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/MainWindow.glade");
                Gui.Autoconnect(this);
                Application.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void  ButtonCreate(object sender, EventArgs a)
        {
            nameBank = Entry1.Text;
            Dialog1.Visible = false;
            ApplicationWindow1.Visible = true;
            bank = new Bank<Account>(nameBank);
        }
        
        protected void  ButtonExit(object sender, EventArgs a)
        {
            Application.Quit();
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
        
        protected void menuFileNew(object sender, EventArgs a)
        {
            new MainWindow();
            Gtk.Application.Quit();
        }
        
        protected void menuExit(object sender, EventArgs a)
        {
            Gtk.Application.Quit();
        }
        
        protected void menuInfoAbout(object sender, EventArgs a)
        {
            AboutDialog1.Visible = true;
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