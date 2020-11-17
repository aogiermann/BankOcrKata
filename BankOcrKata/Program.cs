﻿using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace BankOcrKata {
    internal class Program {
        private static void Main(string[] args) {

            if (args.Any() && File.Exists(args[0])) {
                IBankAccountManager bankAccountManager = new BankAccountManager(new AccountNumberParser(), new CheckSumValidator());
                ReadOnlyCollection<BankAccount> accounts = bankAccountManager.ManageAccounts(args[0]);

                foreach (BankAccount account in accounts) {
                    Console.WriteLine(account.ToString());
                }
            }
            else {
                Console.WriteLine("Lack of input file or file does't exists!");
            }

            Console.ReadLine();
        }
    }
}