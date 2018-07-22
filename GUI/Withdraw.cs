using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class Withdraw
    {
        [Builder.Object]
        private TextBuffer textbuffer1;
        [Builder.Object]
        private TextBuffer textbuffer2;
        
        private Bank<Account> bank;
        
        public Withdraw(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Withdraw.glade");
            Gui.Autoconnect(this);
            Gtk.Application.Run();
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            var sum = Convert.ToDouble(textbuffer2.Text);
            var id = Convert.ToInt32(textbuffer1.Text);
            bank.Withdraw(sum, id);
        }
    }
}