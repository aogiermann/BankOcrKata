using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankOcrKata;
using System.IO;
using System.Linq;
using System;

namespace BankOcrTests {
    [TestClass]
    public class BankAccountManagerTests {
        private IBankAccountManager _bankAccountManager;
        private IAccountNumberParser _accountNumberParser;
        private ICheckSumValidator _checkSumValidator;

        private string _testFileContent;
        private string _testFilePath;
        
        [TestInitialize]
        public void Setup() {
            _accountNumberParser = new AccountNumberParser();
            _checkSumValidator = new CheckSumValidator();

            _bankAccountManager = new BankAccountManager(_accountNumberParser, _checkSumValidator);

            _testFilePath = @"..\..\..\testInput.txt";
            _testFileContent = File.ReadAllText(@"..\..\..\testInput.txt");
        }

        [TestMethod]
        public void ManageAccounts_InputOK_ReturnTrue() {
            var result = _bankAccountManager.ManageAccounts(_testFilePath);

            Assert.IsTrue(result[0].AccountNumber == "490867715" && result[0].IsValid == true);
            Assert.IsTrue(result[1].AccountNumber == "000000000" && result[1].IsValid == true);
            Assert.IsTrue(result[2].AccountNumber == "111111111" && result[2].IsValid == false);
            Assert.IsTrue(result[3].AccountNumber == "222222222" && result[3].IsValid == false);
            Assert.IsTrue(result[4].AccountNumber == "333333333" && result[4].IsValid == false);
            Assert.IsTrue(result[5].AccountNumber == "444444444" && result[5].IsValid == false);
            Assert.IsTrue(result[6].AccountNumber == "555555555" && result[6].IsValid == false);
            Assert.IsTrue(result[7].AccountNumber == "666666666" && result[7].IsValid == false);
            Assert.IsTrue(result[8].AccountNumber == "777777777" && result[8].IsValid == false);
            Assert.IsTrue(result[9].AccountNumber == "888888888" && result[9].IsValid == false);
            Assert.IsTrue(result[10].AccountNumber == "999999999" && result[10].IsValid == false);
            Assert.IsTrue(result[11].AccountNumber == "123456789" && result[11].IsValid == true);
            Assert.IsTrue(result[12].AccountNumber == "000000051" && result[12].IsValid == true);
            Assert.IsTrue(result[13].AccountNumber == "490067715" && result[13].IsValid == false);
            Assert.IsTrue(result[14].AccountNumber == "123456789" && result[14].IsValid == true);
        }

        [TestMethod]
        public void ManagAccount_InputOK_ReturnTrue() {
            var result = _bankAccountManager.ManageAccount(_testFileContent.Split(Environment.NewLine).Take(4).ToArray());

            Assert.IsTrue(result.AccountNumber == "490867715" && result.IsValid == true);
        }

        [TestMethod]
        public void ManagAccount_InputNOK_ThrowException() {
            Assert.ThrowsException<Exception>(() => _bankAccountManager.ManageAccount(_testFileContent.Split(Environment.NewLine).Skip(1).Take(4).ToArray()));
        }
    }
}
