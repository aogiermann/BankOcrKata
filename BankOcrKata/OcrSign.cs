using System.Collections;

namespace BankOcrKata {
    internal class OcrSign {
        //each property represents a BIT like in Seven-digit display.
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool E { get; set; }
        public bool F { get; set; }
        public bool G { get; set; }

        private int _binValueAsInt {
            get {
                int[] intValue = new int[1];
                BitArray bitArray = new BitArray(new bool[] { G, F, E, D, C, B, A });

                bitArray.CopyTo(intValue, 0);
                return intValue[0];
            }
        }

        public int? ConvertToInt() {
            switch (_binValueAsInt) {
                case 126:
                return 0;

                case 48:
                return 1;

                case 109:
                return 2;

                case 121:
                return 3;

                case 51:
                return 4;

                case 91:
                return 5;

                case 95:
                return 6;

                case 112:
                return 7;

                case 127:
                return 8;

                case 123:
                return 9;

                default:
                //return null for NaN values (A, B, C...)
                return null;
            }
        }

        public override string ToString() {
            int? value = ConvertToInt();
            return value is null ? "?" : value.ToString();
        }
    }
}