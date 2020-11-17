using System.Collections.ObjectModel;

namespace BankOcrKata {
    public interface IBankAccountManager {
        BankAccount ManageAccount(string[] input);

        ReadOnlyCollection<BankAccount> ManageAccounts(string filePath);
    }
}