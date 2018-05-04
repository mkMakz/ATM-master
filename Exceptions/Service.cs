using KKB.Bank.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneratorName;



namespace Exceptions
{
    public class Service
    {
        private static Random rnd = new Random();

        public static void CreateClient(ref Client c)
        {
            Generator gen = new Generator();
            c.FullName = gen.GenerateDefault(Gender.woman);
            c.IIN = "123456789123";
            c.PhoneNumber = "7776840017";
            c.DoB = DateTime.Now;

            for (int i = 0; i < rnd.Next(1, 8); i++)
            {
                c.ListAccount.Add(CreateAccountList());
            }
        }



        public static Account CreateAccountList()
        {
           
           Account acc = new Account();
           acc.AccountNumber = "KZ" + rnd.Next(11111, 999999);
           acc.CreateDate = DateTime.Now.AddMonths(-rnd.Next(1, 56));
           acc.Balance = double.Parse(rnd.Next(1000, 99999).ToString());

           return acc;

        }

    }
}
