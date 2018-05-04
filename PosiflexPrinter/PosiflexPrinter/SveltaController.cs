using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterUtility;

namespace PosiflexPrinter {

    class SveltaController {

        public string PrinterName { get; set; }

        public void PrintData() {
            
            byte[] bytesValue = { };

            bytesValue = PrintExtensions.AddBytes(bytesValue, changePrinterEmulationToSvelta());
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello");
            bytesValue = PrintExtensions.AddBytes(bytesValue, "<DATE>");
            bytesValue = PrintExtensions.AddBytes(bytesValue, "<OXY 30,30>");
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello");

            bytesValue = PrintExtensions.AddBytes(bytesValue, "<P>");


            this.print(bytesValue);
        }
        

        void print(byte[] bytesValue) {
            
            try {

                PrintExtensions.Print(bytesValue, this.PrinterName);
            }catch {

                Console.WriteLine("PrintExtensions.Print fail");
            }
        }

        private static byte[] changePrinterEmulationToSvelta() {
            
            byte[] bytes = { 0x1C, 0x3C, 0x53, 0x56, 0x45, 0x4C, 0x3E };
            return bytes;
        }
    }
}
