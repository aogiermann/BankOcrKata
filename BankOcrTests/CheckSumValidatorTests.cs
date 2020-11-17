using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BankOcrKata;

namespace BankOcrTests {
    [TestClass]
    public class CheckSumValidatorTests {
        private ICheckSumValidator _checkSumValidator;

        [TestInitialize]
        public void Setup() {
            _checkSumValidator = new CheckSumValidator();
        }

        [TestMethod]
        public void ValidateCheckSum_InputIsOK_ReturnTrue() {
            var result = _checkSumValidator.ValidateCheckSum("490867715");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ValidateCheckSum_InputIsNOK_ReturnFalse() {
            var result = _checkSumValidator.ValidateCheckSum("222222222");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ValidateCheckSum_InputIsNan_ThrowsEx() {
            Assert.ThrowsException<Exception>(() =>  _checkSumValidator.ValidateCheckSum("2222AB222"), "Invalid account number format!");
        }

        [TestMethod]
        public void ValidateCheckSum_InputIsTooLong_ThrowsEx() {
            Assert.ThrowsException<Exception>(() => _checkSumValidator.ValidateCheckSum("12234567890"), "Invalid account number format!");
        }

        [TestMethod]
        public void ValidateCheckSum_InputIsTooShort_ThrowsEx() {
            Assert.ThrowsException<Exception>(() => _checkSumValidator.ValidateCheckSum("1223"), "Invalid account number format!");
        }
    }
}
