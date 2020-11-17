namespace BankOcrKata {
    public interface IAccountNumberParser {

        /// <summary>
        /// Parse input into string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string ParseAccountNumber(string[] input);
    }
}