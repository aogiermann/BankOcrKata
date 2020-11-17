namespace BankOcrKata {
    public interface ICheckSumValidator {

        /// <summary>
        /// Validates given account number.
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        bool ValidateCheckSum(string accountNumber);
    }
}