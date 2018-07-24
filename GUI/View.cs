﻿using Gtk;
using System;
using  BankLibrary;

namespace BankApplication
{
    class View
    {
        [Builder.Object] private TextBuffer textbuffer1;
        
        private Bank<Account> bank;

        public View(Bank<Account> _bank)
        {
            bank = _bank;
            Gtk.Application.Init();
            Builder Gui = new Builder();
            try
            {
                Gui.AddFromFile(
                    "/home/danila/Documents/VisualCode/cSharp/BankApplication/BankApplication/GUI/View.glade");
                Gui.Autoconnect(this);
                textbuffer1.Text = bank.View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}