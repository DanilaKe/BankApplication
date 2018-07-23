using Gtk;
using BankLibrary;
using System;

namespace BankApplication
{
    public class DialogWindow : Gtk.Window
    {
        [Builder.Object] private TextBuffer textbuffer1;
        Builder Gui = new Builder();

        public DialogWindow(string title) : base(title)
        {
        }

        public DialogWindow(AccountEventArgs e,string title) : base(title)
        {
            Gtk.Application.Init();
            Gui.AddFromFile(
                "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/DialogWindow.glade");
            Gui.Autoconnect(this);
            textbuffer1.Text = e.Message;
        }  

    }
}