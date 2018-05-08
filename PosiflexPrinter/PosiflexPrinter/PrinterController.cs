using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosiflexPrinter {

    class PrinterController {

        public static string PrinterName { get; set; }

        public static void PrintQRCode(string data) {

            byte[] bytesValue = { 0x1B, Convert.ToByte('@') };


            //bytesValue = PrintExtensions.AddBytes(bytesValue, PrinterController.getQRCode(data, 16));
            bytesValue = PrintExtensions.AddBytes(bytesValue, "Hello world");
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });

            // line feed
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, PrinterController.getCutPage());

            PrinterController.print(bytesValue);
        }

        // 1 <= size <= 16
        private static byte[] getQRCode(string data, int size) {

            int data_len = Encoding.UTF8.GetBytes(data).Length + 3;
            byte store_pL = (byte)(data_len % 256);
            byte store_pH = (byte)(data_len / 256);
            
            byte[] bytesValue = { };

            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x41, 0x32, 0x00 });
            // set the QR code size
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, (byte)size });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x45, 0x31 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, store_pL, store_pH, 0x31, 0x50, 0x30 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, Encoding.UTF8.GetBytes(data));
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, 0x30 });

            return bytesValue;
        }

        private static byte[] getCutPage() {

            byte[] bytes = { 0x1B, 0x69 };
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
