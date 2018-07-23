using BankLibrary;
using System;
using Gtk;

namespace BankApplication
{
    public class Put
    {
        [Builder.Object]
        private TextBuffer textbuffer1;
        [Builder.Object]
        private TextBuffer textbuffer2;
        
        private Bank<Account> bank;
        
        public Put(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Put.glade");
            Gui.Autoconnect(this);
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            var sum = Convert.ToDouble(textbuffer2.Text);
            var id = Convert.ToInt32(textbuffer1.Text);
            bank.Put(sum, id);
        }
    }
}