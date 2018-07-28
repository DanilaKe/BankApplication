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

        public static OpenAccount openAccount { get; set; }
        public static Withdraw withdraw{ get; set; }
        public static Put put{ get; set; }
        public static Transfer transfer{ get; set; }
        public static CloseAccount closeAccount{ get; set; }
        public static View view{ get; set; }

        private Builder Gui;
        
        public MainWindow()
        {
            Gtk.Application.Init();
            Gui = new Builder();
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
            if(openAccount == null)
                openAccount = new OpenAccount(bank);
            else
                openAccount.VisibleWindow();
        }
 
        private static void Withdraw()
        {
            if(withdraw == null)
                withdraw = new Withdraw(bank);
            else
                withdraw.VisibleWindow();
        }
 
        private static void Put()
        {
            if(put == null)
                put = new Put(bank);
            else
                put.VisibleWindow();
        }
        
        private static void Transfer()
        {
            if(transfer == null)
                transfer = new Transfer(bank);
            else
                transfer.VisibleWindow();
        }
 
        private static void CloseAccount()
        {
            if(closeAccount == null)
                closeAccount = new CloseAccount(bank);
            else
                closeAccount.VisibleWindow();
        }
        
        private static void ViewWindow()
        {
            if(view == null)
                view =new View(bank);
            else
                view.VisibleWindow();
        }

        protected void CloseWindow(object sender, EventArgs e)
        {
            Application.Quit();
        }

        protected void CloseAboutWindow(object sender, EventArgs e)
        {
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/MainWindow.glade");
            Gui.Autoconnect(this);
        }
    }
}