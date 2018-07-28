using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class Withdraw
    {
        [Builder.Object] private Entry Entry1;
        [Builder.Object] private Entry Entry2;
        [Builder.Object] private ApplicationWindow ApplicationWindow1;
        
        private Bank<Account> bank;
        
        public Withdraw(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Withdraw.glade");
                Gui.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void ButtonWithdraw(object sender, EventArgs a)
        {
            try
            {
                var sum = Convert.ToDouble(Entry2.Text);
                var id = Convert.ToInt32(Entry1.Text);
                bank.Withdraw(sum, id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        protected static void CloseWindow(object sender, EventArgs e)
        {
            MainWindow.withdraw = null;
        }
        
        protected void ButtonExit(object sender, EventArgs a)
        {
            ApplicationWindow1.Visible = false;
        }
        
        public void VisibleWindow()
        {
            ApplicationWindow1.Visible = true;
        }
    }
}