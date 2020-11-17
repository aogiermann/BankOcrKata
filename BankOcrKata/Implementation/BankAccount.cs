namespace BankOcrKata {

    /// <summary>
    /// Record representing bank account entry.
    /// </summary>
    public record BankAccount {
        public string AccountNumber { get; set; }
        public bool IsValid { get; set; }

        public override string ToString() {
            return $"{AccountNumber} - Valid: {IsValid}";
        }
    }
}
