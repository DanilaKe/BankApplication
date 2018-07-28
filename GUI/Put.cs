using BankLibrary;
using System;
using Gtk;

namespace BankApplication
{
    public class Put
    {
        [Builder.Object] private Entry Entry1;
        [Builder.Object] private Entry Entry2;
        [Builder.Object] private Window Window1;

        private Bank<Account> bank;
        
        public Put(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/Put.glade");
                Gui.Autoconnect(this);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        
        protected void ButtonPut(object sender, EventArgs a)
        {
            try
            {
                var sum = Convert.ToDouble(Entry2.Text);
                var id = Convert.ToInt32(Entry1.Text);
                bank.Put(sum, id);
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
        
        public void VisibleWindow()
        {
            Window1.Visible = true;
        }
    }
}