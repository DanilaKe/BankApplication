using BankLibrary;
using System;
using Gtk;

namespace BankApplication
{
    public class Transfer
    {
        [Builder.Object]
        private TextBuffer textbuffer1;
        [Builder.Object]
        private TextBuffer textbuffer2;
        [Builder.Object]
        private TextBuffer textbuffer3;
        
        private Bank<Account> bank;
        
        public Transfer(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Transfer.glade");
            Gui.Autoconnect(this);
        }
        
        protected void ButtonOK(object sender, EventArgs a)
        {
            var sum = Convert.ToDouble(textbuffer3.Text);
            var id1 = Convert.ToInt32(textbuffer1.Text);
            var id2 = Convert.ToInt32(textbuffer2.Text);
            bank.Transfer(sum, id1, id2);
        }
    }
}