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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SendBase64 {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        const string imgPath = @"D:\github\TerrenceHuang\wpf-test\Base64\Base64\Sprites\angular.jpg";
        BitmapImage bitmapImage;
        string base64Image;

        const string id = "PORTWELLSEND";
        const string pubTopic = "/Base64/img";
        MqttClient mqttClient;

        public MainWindow() {

            InitializeComponent();

            this.bitmapImage = this.loadImage();
            this.base64Image = this.imageToBase64();
            this.initMqttClient();
        }

        void initMqttClient() {

            this.mqttClient = new MqttClient("127.0.0.1", 1883, false, null, null, MqttSslProtocols.None);
            this.mqttClient.Connect(id);
        }

        BitmapImage loadImage() {

            byte[] buffers = File.ReadAllBytes(MainWindow.imgPath);
            MemoryStream ms = new MemoryStream(buffers);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = ms;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }

        string imageToBase64() {

            MemoryStream stream = this.bitmapImage.StreamSource as MemoryStream;
            //stream.Position = 0;
            //BinaryReader binaryReader = new BinaryReader(stream);
            //byte[] byteImage = binaryReader.ReadBytes((int)stream.Length);
            byte[] byteImage = stream.ToArray();

            return  Convert.ToBase64String(byteImage);
        }

        void Button_Click(object sender, RoutedEventArgs e) {

            Console.WriteLine(this.base64Image);
            this.mqttClient.Publish(MainWindow.pubTopic, Encoding.UTF8.GetBytes(this.base64Image), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        }
    }
}
