using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class CloseAccount
    {
        [Builder.Object]
        private Entry Entry1;

        [Builder.Object] private ApplicationWindow ApplicationWindow1;
        
        private Bank<Account> bank;
        
        public CloseAccount(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/CloseAccount.glade");
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
                var id = Convert.ToInt32(Entry1.Text);
                bank.Close(id);
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
    }
}