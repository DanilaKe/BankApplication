using BankLibrary;
using System;
using Gtk;

namespace BankApplication
{
    public class Transfer
    {
        [Builder.Object] private Entry Entry1;
        [Builder.Object] private Entry Entry2;
        [Builder.Object] private Entry Entry3;
        [Builder.Object] private Window Window1;
        
        private Bank<Account> bank;
        
        public Transfer(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Transfer.glade");
                Gui.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void ButtonTransfer(object sender, EventArgs a)
        {
            try
            {
                var sum = Convert.ToDouble(Entry3.Text);
                var id1 = Convert.ToInt32(Entry1.Text);
                var id2 = Convert.ToInt32(Entry2.Text);
                bank.Transfer(sum, id1, id2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void ButtonExit(object sender, EventArgs a)
        {
            Window1.Visible = false;
        }
    }
}