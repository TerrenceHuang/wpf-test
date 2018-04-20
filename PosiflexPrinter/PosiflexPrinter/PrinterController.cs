﻿using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosiflexPrinter {

    class PrinterController {

        public static void PrintQRCode() {

            byte[] bytesValue = { 0x1B, Convert.ToByte('@') };


            bytesValue = PrintExtensions.AddBytes(bytesValue, PrinterController.getQRCode(@"You are ugly", 16));
            

            // line feed
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x0A });
            bytesValue = PrintExtensions.AddBytes(bytesValue, PrinterController.getCutPage());

            try {

                PrintExtensions.Print(bytesValue, @"\\localhost\Posiflex PP7600 Printer");
            }catch {

            }
        }

        // 1 <= size <= 16
        private static byte[] getQRCode(string data, int size) {

            int data_len = data.Length + 3;
            byte store_pL = (byte)(data_len % 256);
            byte store_pH = (byte)(data_len / 256);

            byte[] bytesValue = { };

            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x41, 0x32, 0x00 });
            // set the QR code size
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x43, (byte)size });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x45, 0x31 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, store_pL, store_pH, 0x31, 0x50, 0x30 });
            bytesValue = PrintExtensions.AddBytes(bytesValue, data);
            bytesValue = PrintExtensions.AddBytes(bytesValue, new byte[] { 0x1D, 0x28, 0x6B, 0x03, 0x00, 0x31, 0x51, 0x30 });

            return bytesValue;
        }

        private static byte[] getCutPage() {

            byte[] bytes = { 0x1B, 0x69 };
            return bytes;
        }
    }
}
