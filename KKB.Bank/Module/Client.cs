using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KKB.Bank.Module
{
    public class Client
    {
        public Client()
        {
            ListAccount = new List<Account>();
        }

      public string FullName { get; set; }

        private string IIN_;

      public string IIN {
            get
            {
                return IIN_;
            }
            set { if (value.Length == 12)
                {
                    IIN_ = value;

                }
            else
                {
                    throw new Exception("Invalid sequence of IIN");

                }

            }

        }   
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get;  set; }
        public string Password { get; set; }
        public List<Account> ListAccount;

        private int WrongField_ = 3;
        public bool isBlocked { get; set; } = false;
        public int WrongField
        {
            get
            {
                return WrongField_;
            }

            set
            {
                if (value == 0)
                    isBlocked = true;
                WrongField_ = value; 
            }
        }

        double sumBalance = 0; 

        public void PrintAccount()
        {
            foreach (Account item in ListAccount)
            {
                Console.WriteLine("Account Number {0}", item.AccountNumber);
                Console.WriteLine("Account Ballance {0}",item.Balance);
                Console.WriteLine("Creation date {0}", item.CreateDate);
                Console.WriteLine("Expired date {0}", item.CloseDate);

                sumBalance += item.Balance;
            }
            Console.WriteLine("\n Total : {0}", sumBalance);
        }


    }
}
