using System;
using System.IO.Ports;
using System.Threading.Tasks;

namespace SerialPortController {

    class SerialPortController {

        #region Properties

        public string PortName {
            get { return this.serialPort.PortName; }
        }

        public int BaudRate {
            get { return this.serialPort.BaudRate; }
        }

        #endregion

        #region Fields
        
        SerialPort serialPort;

        #endregion


        #region Constructors

        public SerialPortController(string portName, int baudRate) {
            
            this.serialPort = new SerialPort();
            this.serialPort.PortName = portName;
            this.serialPort.BaudRate = baudRate;
            this.serialPort.WriteTimeout = SerialPort.InfiniteTimeout;
        }

        #endregion

        #region Methods

        public static string[] getPortNames() {

            return SerialPort.GetPortNames();
        }

        public async Task sendStr(string str) {
            
            while (this.serialPort.IsOpen) {

                await Task.Delay(10);
            }

            this.serialPort.Open();
            await Task.Run(() => {

                this.serialPort.Write(str);
            });
            this.serialPort.Close();
        }

        #endregion
    }
}
