using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOcrKata {
    public class AccountNumberParser : IAccountNumberParser {
        private const int DIGIT_AMOUNT = 9;
        private const int DIGIT_COLS = 3;
        private const int LINES_NUMBERS = 3;

        /// <summary>
        /// Basing on input validates and parse account number into string. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string ParseAccountNumber(string[] input) {
            StringBuilder result = new StringBuilder();

            validateInput(input);

            List<OcrSign> ocrDigits = getDigits(input);

            foreach (OcrSign ocrDigit in ocrDigits) {
                result.Append(ocrDigit.ToString());
            }

            return result.ToString();
        }

        /// <summary>
        /// Basing on input parses account number. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<OcrSign> getDigits(string[] input) {
            var ocrDigits = new List<OcrSign>();

            for (int index = 0; index < DIGIT_AMOUNT; index++) {
                int digitStart = index * DIGIT_COLS;
                OcrSign ocrDigit = new OcrSign();

                ocrDigit.A = input[0].ToCharArray()[digitStart + 1] == '_';

                (ocrDigit.F, ocrDigit.G, ocrDigit.B) = getBits(input[1].ToCharArray(), digitStart);
                (ocrDigit.E, ocrDigit.D, ocrDigit.C) = getBits(input[2].ToCharArray(), digitStart);

                ocrDigits.Add(ocrDigit);
            }

            return ocrDigits;

            static (bool, bool, bool) getBits(char[] line, int digitStart) {
                bool[] bits = new bool[3];

                bits[0] = line[digitStart] == '|';
                bits[1] = line[digitStart + 1] == '_';
                bits[2] = line[digitStart + 2] == '|';

                return (bits[0], bits[1], bits[2]);
            }
        }

        /// <summary>
        /// Valdates given input according to rules mentioned in kata: http://codingdojo.org/kata/BankOCR/#problem-description
        /// </summary>
        /// <param name="input"></param>
        private void validateInput(string[] input) {
            char[] charsToTrim = new char[] { '\n', '\r' };

            if (input.Any(x => x.TrimEnd(charsToTrim).Length < 27) || input.Length != LINES_NUMBERS) {
                throw new Exception("Input in incorrect format!");
            }
        }
    }
}