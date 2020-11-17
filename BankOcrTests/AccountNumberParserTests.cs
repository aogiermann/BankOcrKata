using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BankOcrKata;

namespace BankOcrTests {
    [TestClass]
    public class AccountNumberParserTests {
        private IAccountNumberParser _accountNumberParser;

        private string _correctAccountNumber = @"    _  _  _  _  _  _     _ 
|_||_|| ||_||_   |  |  ||_ 
  | _||_||_||_|  |  |  | _|";

        [TestInitialize]
        public void Setup() {
            _accountNumberParser = new AccountNumberParser();
        }

        [TestMethod]
        public void GetAccountNumber_InputIsOK_ReturnTrue() {
            string accountNumber = "490867715";

            var result = _accountNumberParser.ParseAccountNumber(_correctAccountNumber.Split('\n'));

            Assert.IsTrue(accountNumber == result);
        }
    }
}
