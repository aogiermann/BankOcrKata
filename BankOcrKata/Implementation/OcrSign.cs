using System.Collections;

namespace BankOcrKata {
    internal class OcrSign {

        //Each property represents a BIT like in Seven-digit display.
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool E { get; set; }
        public bool F { get; set; }
        public bool G { get; set; }

        /// <summary>
        /// Convert digit binary value into decimal value.
        /// </summary>
        private int _binaryValueAsInt {
            get {
                int[] intValue = new int[1];
                BitArray bitArray = new BitArray(new bool[] { G, F, E, D, C, B, A });

                bitArray.CopyTo(intValue, 0);
                return intValue[0];
            }
        }

        /// <summary>
        /// Converts hex values of digit into number.
        /// Return null for NaN values.
        /// </summary>
        /// <returns></returns>
        public int? ConvertToInt() {
            return _binaryValueAsInt switch {
                126 => 0,
                48 => 1,
                109 => 2,
                121 => 3,
                51 => 4,
                91 => 5,
                95 => 6,
                112 => 7,
                127 => 8,
                123 => 9,
                _ => null,//return null for NaN values (A, B, C...)
            };
        }

        public override string ToString() {
            int? value = ConvertToInt();
            return value is null ? "?" : value.ToString();
        }
    }
}