using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace RecvBase64 {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        const string id = "PORTWELLRecv";
        const string subTopic = "/Base64/img";
        MqttClient mqttClient;

        public MainWindow() {

            InitializeComponent();
            this.initMqttClient();
        }

        void initMqttClient() {

            this.mqttClient = new MqttClient("127.0.0.1", 1883, false, null, null, MqttSslProtocols.None);
            this.mqttClient.MqttMsgPublishReceived += this.mqttClient_MqttMsgReceived;
            this.mqttClient.Connect(MainWindow.id);
            this.mqttClient.Subscribe(new string[] { MainWindow.subTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }

        BitmapImage Base64ToImage(string base64String) {

            BitmapImage bitmapImage = new BitmapImage();

            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes);

            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        void mqttClient_MqttMsgReceived(object sender, MqttMsgPublishEventArgs e) {

            if (e.Topic == MainWindow.subTopic) {

                string recvMsg = Encoding.UTF8.GetString(e.Message);
                Console.WriteLine(recvMsg);
                Dispatcher.BeginInvoke(new Action(() => {

                    this.Image.Source = this.Base64ToImage(recvMsg);
                }), DispatcherPriority.Background);
            }
        }
    }
}
