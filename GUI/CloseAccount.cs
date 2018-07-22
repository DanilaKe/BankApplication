using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class CloseAccount
    {
        [Builder.Object]
        private TextBuffer textbuffer1;
        
        private Bank<Account> bank;
        
        public CloseAccount(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/CloseAccount.glade");
            Gui.Autoconnect(this);
            Gtk.Application.Run();
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            var id = Convert.ToInt32(textbuffer1.Text);
            bank.Close(id);
        }
    }
}