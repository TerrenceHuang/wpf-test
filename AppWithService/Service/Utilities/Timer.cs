using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Utilities {

    class Timer {

        public delegate void ChangeTextDelegate(string text);
        public ChangeTextDelegate changeTextDelegate;

        private readonly string[] texts = { "Hi there", "Good morning", "Awesome" };
        private int index = 0;

        public void start() {

            this.changeService();
        }

        async Task changeService() {

            do {

                if (changeTextDelegate != null) {

                    string text = this.getText();

                    changeTextDelegate(text);
                }
                await Task.Delay(3000);
            } while (true);
        }

        string getText() {
            
            if (++this.index == this.texts.Length) {

                this.index = 0;
            }

            return this.texts[index];
        }
    }
}
