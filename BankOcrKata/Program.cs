using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace BankOcrKata {
    internal class Program {
        private static void Main(string[] args) {

            if (args.Any() && File.Exists(args[0])) {
                IBankAccountManager bankAccountManager = new BankAccountManager(new AccountNumberParser(), new CheckSumValidator());
                ReadOnlyCollection<BankAccount> accounts = bankAccountManager.ManageAccounts(args[0]);

                if (accounts != null) {
                    foreach (BankAccount account in accounts) {
                        Console.WriteLine(account);
                    }
                }
                else {
                    Console.WriteLine("No accounts found in input file.");
                }
            }
            else {
                Console.WriteLine("Lack of input file or file doesn't exist!");
            }

            Console.ReadLine();
        }
    }
}