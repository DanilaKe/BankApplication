using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class DialogWindow 
    {
    
        [Builder.Object] private TextBuffer textbuffer1;

        [Builder.Object] private Dialog Dialog1;
        Builder Gui = new Builder();

        public DialogWindow(AccountEventArgs e) 
        {
            Gtk.Application.Init();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/DialogWindow.glade");
                Gui.Autoconnect(this);
                textbuffer1.Text = e.Message;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }  
        
        protected void ButtonClose(object sender, EventArgs a)
        {
            Dialog1.Visible = false;
        }

    }
}