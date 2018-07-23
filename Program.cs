using System;
using Gtk;
using BankLibrary;


namespace BankApplication
{
    class Program
    {
        static Bank<Account> bank = new Bank<Account>("ЮнитБанк");
        
        static void Main(string[] args)
        {
            new MainWindow();
        }
        
    }
}
