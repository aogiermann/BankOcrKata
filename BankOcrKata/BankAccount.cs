using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOcrKata {
    public record BankAccount {
        public string AccountNumber { get; set; }
        public bool IsValid { get; set; }

        public override string ToString() {
            return $"{AccountNumber} - Valid: {IsValid}";
        }
    }
}
