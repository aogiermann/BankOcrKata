using System;
using System.Text.RegularExpressions;

namespace BankOcrKata {
    public class CheckSumValidator : ICheckSumValidator {
        public bool ValidateCheckSum(string accountNumber) {
            if (accountNumber.Length != 9 || !Regex.IsMatch(accountNumber, "^[0-9]*$")) {
                throw new Exception("Invalid account number format!");
            }

            int intermediateSum = 0;
            char[] reversedNumer = accountNumber.ToCharArray();
            Array.Reverse(reversedNumer);

            for (int index = 0; index < reversedNumer.Length; index++) {
                int value = int.Parse(reversedNumer[index].ToString());
                intermediateSum += value * (index + 1);
            }

            return intermediateSum % 11 == 0;
        }
    }
}