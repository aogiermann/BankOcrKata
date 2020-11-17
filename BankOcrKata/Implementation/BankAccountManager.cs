using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace BankOcrKata {
    public class BankAccountManager : IBankAccountManager {
        
        const int LINES_BATCH_SIZE = 4;

        private readonly IAccountNumberParser _accountNumberParser;
        private readonly ICheckSumValidator _checkSumValidator;

        public BankAccountManager(IAccountNumberParser accountNumberParser, ICheckSumValidator checkSumValidator) {
            _accountNumberParser = accountNumberParser;
            _checkSumValidator = checkSumValidator;
        }

        /// <summary>
        /// Manages and returns valid account numbers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public BankAccount ManageAccount(string[] input) {
            string accountNumber;
            bool isValid;

            accountNumber = _accountNumberParser.ParseAccountNumber(input);
            isValid = _checkSumValidator.ValidateCheckSum(accountNumber);

            return new BankAccount() { AccountNumber = accountNumber, IsValid = isValid };
        }

        /// <summary>
        /// Manages and returns accounts for given file.
        /// </summary>
        /// <param name="filePath">File containing accounts numbers.</param>
        /// <returns></returns>
        public ReadOnlyCollection<BankAccount> ManageAccounts(string filePath) {

            if (File.Exists(filePath)) {
                string[] input = File.ReadAllText(filePath).Split(Environment.NewLine);

                List<BankAccount> accounts = new List<BankAccount>();

                for (int i = 0; i < input.Length / LINES_BATCH_SIZE; i++) {
                    string[] accountInput = input.Skip(i * LINES_BATCH_SIZE).Take(LINES_BATCH_SIZE).ToArray();

                    try {
                        accounts.Add(ManageAccount(accountInput));
                    }
                    catch (Exception ex) {
                        Console.WriteLine($"Exception during parse: {ex.Message}");
                    }
                }

                return new ReadOnlyCollection<BankAccount>(accounts);
            }

            return null;
        }
    }
}
