using System;

namespace SerialPortController {

    class Program {

        #region Fields

        static readonly string portName = "com5";
        static readonly int baudRate = 115200;

        static SerialPortController SerialPortController;

        #endregion

        #region Methods

        static void Main(string[] args) {

            //Program.printList(SerialPortController.getPortNames());

            Program.SerialPortController = new SerialPortController(Program.portName, Program.baudRate);

            Program.startSend();

            Console.ReadLine();
        }

        static void startSend() {

            bool notEnd = true;
            string message;
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            Console.WriteLine("Connect to port: {0}, baud rate: {1}", portName, baudRate);

            Console.WriteLine("Type QUIT to exit");
            while (notEnd) {

                message = Console.ReadLine();

                if (stringComparer.Equals("quit", message)) {

                    notEnd = false;
                }else {

                    Program.SerialPortController.sendStr(message);
                }
            }
        }

        static void printList(string[] list) {

            foreach (string str in list) {

                Console.WriteLine(str);
            }
        }

        #endregion
    }
}
