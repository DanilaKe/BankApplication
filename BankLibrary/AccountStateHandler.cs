using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace BankLibrary
{
    public delegate void AccountStateHandler(object sender, AccountEventArgs e);
 
    public class AccountEventArgs
    {
        public string Message { get; }
        public double Sum { get; }
 
        public AccountEventArgs(string _mes, double _sum)
        {    
            Message = _mes;
            Sum = _sum;
        }
    }
}