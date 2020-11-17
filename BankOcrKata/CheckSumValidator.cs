using System;
using System.Text.RegularExpressions;

namespace BankOcrKata {
    public class CheckSumValidator : ICheckSumValidator {

        /// <summary>
        /// Validates account number with pattern:
        /// account number:  3  4  5  8  8  2  8  6  5
        /// position names:  d9 d8 d7 d6 d5 d4 d3 d2 d1
        /// checksum calculation:
        /// (d1+2*d2+3*d3+...+9*d9) mod 11 = 0
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
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