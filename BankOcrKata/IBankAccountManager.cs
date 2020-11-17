using System.Collections.ObjectModel;

namespace BankOcrKata {
    public interface IBankAccountManager {
        /// <summary>
        /// Returns single account.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        BankAccount ManageAccount(string[] input);

        /// <summary>
        /// Returns R/O collection of accounts.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        ReadOnlyCollection<BankAccount> ManageAccounts(string filePath);
    }
}