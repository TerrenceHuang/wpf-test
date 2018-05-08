using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterUtility;

namespace PosiflexPrinter {

    class StimaPrinterController {

        static string printerName = @"\\localhost\STIMA";

        static byte[] changePrinterEmulationToEscPos = Encoding.UTF8.GetBytes("<EPOS>");
        static byte[] ESC = { 0x1B };
        static byte[] GS = { 0x1D };
        static byte[] LF = { 0x0A };
        static byte[] cutPage = { 0x1B, 0x69 };
        static byte[] initializePrinter = PrintExtensions.AddBytes(ESC, "@");
        static byte[] boldOn = PrintExtensions.AddBytes(ESC, new byte[] { Convert.ToByte('E'), 0x01 });
        static byte[] boldOff = PrintExtensions.AddBytes(ESC, new byte[] { Convert.ToByte('E'), 0x00 });
        static byte[] doubleOn = PrintExtensions.AddBytes(GS, new byte[] { Convert.ToByte('!'), 0x11 });
        static byte[] doubleOff = PrintExtensions.AddBytes(GS, new byte[] { Convert.ToByte('!'), 0x00 });
        static byte[] centered = PrintExtensions.AddBytes(ESC, new byte[] { Convert.ToByte('a'), 0x01 });
        static byte[] left = PrintExtensions.AddBytes(ESC, new byte[] { Convert.ToByte('a'), 0x00 });

        public static void PrintTicket() {

            byte[] bytesValue = { };
            bytesValue = PrintExtensions.AddBytes(bytesValue, changePrinterEmulationToEscPos);
            bytesValue = PrintExtensions.AddBytes(bytesValue, initializePrinter);

            // set notch distance
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0xE7, 0x00, 0x00 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0xF6 });

            //// rotation
            //bytesValue = PrintExtensions.AddBytes(bytesValue, ESC);
            //bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { Convert.ToByte('V'), 0x49 });

            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello World!"); 
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });

            // line feed
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello There 11");
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1B, 0x64, 0x10 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello There 12");
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });

            // set notch distance
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0xE7, 0x01, 0x30 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, StimaPrinterController.getCutPage());

            StimaPrinterController.print(bytesValue);
        }

        private static byte[] headerTest() {
            
            byte[] bytes = { 0x1B, 0x40, 0x1D, 0xF6 };
            return bytes;
        }

        private static byte[] getCutPage() {

            //byte[] bytes = { 0x1D, 0xF8};
            byte[] bytes = { 0x1D, 0xF8, 0x1B, 0x69 };
            return bytes;
        }

        private static void print(byte[] bytesValue) {
            
            try {

                PrintExtensions.Print(bytesValue, printerName);
            }catch {

                Console.WriteLine("PrintExtensions.Print fail");
            }
        }
    }
}
