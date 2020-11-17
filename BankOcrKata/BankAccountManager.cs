using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOcrKata {
    public class BankAccountManager : IBankAccountManager {
        const int LINES_BATCH_SIZE = 4;

        private readonly IAccountNumberParser _accountNumberParser;
        private readonly ICheckSumValidator _checkSumValidator;

        public BankAccountManager(IAccountNumberParser accountNumberParser, ICheckSumValidator checkSumValidator) {
            _accountNumberParser = accountNumberParser;
            _checkSumValidator = checkSumValidator;
        }

        public BankAccount ManageAccount(string[] input) {
            string accountNumber = String.Empty;
            bool isValid = false;

            accountNumber = _accountNumberParser.ParseAccountNumber(input);
            isValid = _checkSumValidator.ValidateCheckSum(accountNumber);

            return new BankAccount() { AccountNumber = accountNumber, IsValid = isValid };
        }

        public ReadOnlyCollection<BankAccount> ManageAccounts(string filePath) {

            if (File.Exists(filePath)) {
                string[] input = File.ReadAllText(filePath).Split('\n');

                List<BankAccount> accounts = new List<BankAccount>();

                for (int i = 0; i < input.Length / LINES_BATCH_SIZE; i++) {
                    //Taking 3 needed lines out of 4 from each entry.
                    string[] accountInput = input.Skip(i * LINES_BATCH_SIZE).Take(LINES_BATCH_SIZE - 1).ToArray();

                    try {
                        accounts.Add(ManageAccount(accountInput));
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }

                return new ReadOnlyCollection<BankAccount>(accounts);
            }

            return null;
        }
    }
}
