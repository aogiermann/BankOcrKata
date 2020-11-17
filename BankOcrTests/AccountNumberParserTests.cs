using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankOcrKata;

namespace BankOcrTests {
    [TestClass]
    public class AccountNumberParserTests {
        private IAccountNumberParser _accountNumberParser;

        private string _correctAccountNumber = @"    _  _  _  _  _  _     _ 
|_||_|| ||_||_   |  |  ||_ 
  | _||_||_||_|  |  |  | _|
";

        private string _incorrectAccountNumber1 = @"";
        private string _incorrectAccountNumber2 = @"




";
        private string _incorrectAccountNumber3 = @"    _  _  _  _  _  _     _ 
| _ || _ || || _ || _ |  |  || _
  | _ || _ || _ || _ |  |  ";

        private string _incorrectAccountNumber4 = @"    _  _  _  _  _  _     _ 
|_||_|| ||_||_   |  |  ||_ 
  | _||_||_||_|  |  |  | _|

";

        [TestInitialize]
        public void Setup() {
            _accountNumberParser = new AccountNumberParser();
        }

        [TestMethod]
        public void GetAccountNumber_InputIsOK_ReturnTrue() {
            string accountNumber = "490867715";

            var result = _accountNumberParser.ParseAccountNumber(_correctAccountNumber.Split(Environment.NewLine));

            Assert.IsTrue(accountNumber == result);
        }

        [TestMethod]
        public void GetAccountnumber_InputNOK_ThrowsException() {
            Assert.ThrowsException<Exception>(() => _accountNumberParser.ParseAccountNumber(_incorrectAccountNumber1.Split(Environment.NewLine)));
            Assert.ThrowsException<Exception>(() => _accountNumberParser.ParseAccountNumber(_incorrectAccountNumber2.Split(Environment.NewLine)));
            Assert.ThrowsException<Exception>(() => _accountNumberParser.ParseAccountNumber(_incorrectAccountNumber3.Split(Environment.NewLine)));
            Assert.ThrowsException<Exception>(() => _accountNumberParser.ParseAccountNumber(_incorrectAccountNumber4.Split(Environment.NewLine)));
        }
    }
}
