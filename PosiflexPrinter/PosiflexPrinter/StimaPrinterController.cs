using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrinterUtility;

namespace PosiflexPrinter {

    class StimaPrinterController {

        public static string PrinterName { get; set; }

        public static void PrintTicket() {

            byte[] bytesValue = { };
            bytesValue = changePrinterEmulationToEscPos();
            bytesValue = PrintExtensions.AddBytes(bytesValue, StimaPrinterController.headerTest());

            // set notch distance
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0xE7, 0x00, 0x00 });

            //// set 90 rotated print mode
            //bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1B, 0x56, 0x00 });

            //bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0xE7, 0x00, 0x00 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello There 10"); 

            // line feed
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello There 11");
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1B, 0x64, 0x10 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello There 12");
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1C, 0x82 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, StimaPrinterController.getCutPage());

            StimaPrinterController.print(bytesValue);
        }

        private static byte[] changePrinterEmulationToEscPos() {
            
            byte[] bytes = Encoding.UTF8.GetBytes("<EPOS>");
            return bytes;
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

                PrintExtensions.Print(bytesValue, PrinterName);
            }catch {

                Console.WriteLine("PrintExtensions.Print fail");
            }
        }
    }
}
